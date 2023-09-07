using Js.ContactsViewer.Shared.Models;

namespace Js.ContactsViewer.Client.Services;

public interface IContactService
{
    List<Contact> Contacts { get; set; }
    List<Category> Categories { get; set; }
    List<SubCategory> SubCategories { get; set; }

    Task<Contact> GetContactById(int id);
    Task GetContacts();
    Task GetCategories();
    Task GetSubCategories();

}
