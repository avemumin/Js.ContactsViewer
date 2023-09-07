using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Js.ContactsViewer.Client.Services
{
    public class SubCategoryService :ISubCategoryService
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
            if (result != null) SubCategories = result;
        }
    }
}
