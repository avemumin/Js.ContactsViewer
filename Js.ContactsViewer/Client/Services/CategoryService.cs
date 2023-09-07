using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Js.ContactsViewer.Client.Services
{
    public class CategoryService : ICategoryService
    {
        public List<Category> Categories { get; set; } = new List<Category>();

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
    }
}
