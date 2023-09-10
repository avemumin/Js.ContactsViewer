using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Js.ContactsViewer.Client.Services
{
    public class CategoryService : ICategoryService
    {
        public List<Category> Categories { get; set; } = new List<Category>();
        public Category Category { get; set; } = new Category();

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public CategoryService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }


        public async Task GetCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Category>>("api/categories");
            if (result != null) Categories = result;
        }

        public async Task GetCategoryById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Category>($"api/categories/{id}");
            if (result != null)
                Category = result;
        }

        public async Task CreateCategory(Category category)
        {
            var result = await _httpClient.PostAsJsonAsync("api/categories", category);
            await SetCatetoryResult(result);

        }

        public async Task UpdateCategory(Category category)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/categories/{category.Id}", category);
            await SetCatetoryResult(result);
        }
        public async Task DeleteCategory(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/categories/{id}");
            await SetCatetoryResult(result);
        }

        private async Task SetCatetoryResult(HttpResponseMessage result)
        {
            var resposne = await result.Content.ReadFromJsonAsync<List<Category>>();
            if (resposne != null)
                Categories = resposne;
        }

    }
}
