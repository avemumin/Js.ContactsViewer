using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Js.ContactsViewer.Client.Services;

public class ContactService : IContactService
{
    public List<Contact> Contacts { get; set; } = new List<Contact>();
    public Contact Contact { get; set; } = new Contact();

    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;
   
    public ContactService(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
    }

    public async Task GetContacts()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Contact>>("api/contacts");
        if (result != null)
            Contacts = result;
    }
    public async Task<Contact> GetContactById(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<Contact>($"api/contacts/{id}");
        return result is null ? throw new Exception("Contact not exist") : result;
    }

    public async Task CreateContact(Contact contact)
    {
        var result = await _httpClient.PostAsJsonAsync("api/contacts", contact);
        await SetContactResult(result);

    }
    public async Task UpdateContact(Contact contact)
    {
        var result = await _httpClient.PutAsJsonAsync($"api/contacts/{contact.Id}", contact);
        await SetContactResult(result);
    }
    public async Task DeleteContact(int id)
    {
        var result = await _httpClient.DeleteAsync($"api/contacts/{id}");
        await SetContactResult(result);
    }

    private async Task SetContactResult(HttpResponseMessage result)
    {
        var resposne = await result.Content.ReadFromJsonAsync<List<Contact>>();
        if (resposne != null)
            Contacts = resposne;
    }
}








//tutaj mamy serwis dla kontaktu implementujący interfejs IContactService
//następnie wywołujemy asynchroniczne metody celujące w 
//odpowiednie metody Controllera dla ContactsController
