using Js.ContactsViewer.Shared.Models;

namespace Js.ContactsViewer.Client.Services.Interface;

public interface IContactService 
{
    List<Contact> Contacts { get; set; }
    Contact Contact { get; set; }
    Task GetContacts();
    Task<Contact> GetContactById(int id);

    Task CreateContact(Contact contact);
    Task UpdateContact(Contact contact);
    Task DeleteContact(int id);

}
