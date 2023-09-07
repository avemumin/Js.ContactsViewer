using Js.ContactsViewer.Shared.Models;

namespace Js.ContactsViewer.Client.Services.Interface;

public interface IContactService 
{
    List<Contact> Contacts { get; set; }
    Task<Contact> GetContactById(int id);
    Task GetContacts();
}
