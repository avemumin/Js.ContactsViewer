using Js.ContactsViewer.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Js.ContactsViewer.Client.Services;

public class ContactService : IContactService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public ContactService(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
    }

    public List<Contact> Contacts { get; set; } = new List<Contact>();
    public List<Category> Categories { get; set; } = new List<Category>();
    public List<SubCategory> SubCategories { get; set; } = new List<SubCategory>();

    public async Task GetCategories()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Category>>("api/categories");
        if (result != null) Categories = result;
    }

    public async Task<Contact> GetContactById(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<Contact>($"api/contacts/{id}");
        return result is null ? throw new Exception("Contact not exist") : result;
    }

    public async Task GetContacts()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Contact>>("api/contacts");
        if (result != null)
            Contacts = result;
    }

    public async Task GetSubCategories()
    {
        var result = await _httpClient.GetFromJsonAsync<List<SubCategory>>("api/subcategories");
        if (result != null) SubCategories = result;
    }
}
