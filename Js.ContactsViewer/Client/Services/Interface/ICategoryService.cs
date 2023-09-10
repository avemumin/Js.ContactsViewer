namespace Js.ContactsViewer.Client.Services.Interface;

public interface ICategoryService
{
    List<Category> Categories { get; set; }
    Category Category { get; set; }

    Task GetCategories();

    Task GetCategoryById(int id);



    Task CreateCategory(Category subCategory);
    Task UpdateCategory(Category subCategory);
    Task DeleteCategory(int id);
}
