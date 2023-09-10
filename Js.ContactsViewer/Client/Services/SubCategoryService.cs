using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Js.ContactsViewer.Client.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        public List<SubCategory> SubCategories { get; set; } = new List<SubCategory>();

        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public SubCategoryService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task GetSubCategories()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SubCategory>>("api/subcategories");
            if (result != null) 
                SubCategories = result;
        }


        public async Task CreateSubCategory(SubCategory subCategory)
        {
            var result = await _httpClient.PostAsJsonAsync("api/subcategories", subCategory);
            await SetSubcatetoryResult(result);

        }

        public async Task UpdateSubCategory(SubCategory subCategory)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/subcategories/{subCategory.Id}", subCategory);
            await SetSubcatetoryResult(result);
        }
        public async Task DeleteSubCategory(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/subcategories/{id}");
            await SetSubcatetoryResult(result);
        }

        private async Task SetSubcatetoryResult(HttpResponseMessage result)
        {
            var resposne = await result.Content.ReadFromJsonAsync<List<SubCategory>>();
            if (resposne != null)
                SubCategories = resposne;
        }
    }
}
