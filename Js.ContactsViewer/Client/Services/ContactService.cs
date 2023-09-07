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

}
