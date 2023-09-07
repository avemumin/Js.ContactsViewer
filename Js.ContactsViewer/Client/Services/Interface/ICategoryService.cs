namespace Js.ContactsViewer.Client.Services.Interface;

public interface ICategoryService
{
    List<Category> Categories { get; set; }
    Task GetCategories();
}
