namespace Js.ContactsViewer.Client.Services.Interface;

public interface ISubCategoryService
{
    List<SubCategory> SubCategories { get; set; }
    Task GetSubCategories();
}
