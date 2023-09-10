namespace Js.ContactsViewer.Client.Services.Interface;

public interface ISubCategoryService
{
    List<SubCategory> SubCategories { get; set; }
    Task GetSubCategories();



    Task CreateSubCategory(SubCategory subCategory);
    Task UpdateSubCategory(SubCategory subCategory);
    Task DeleteSubCategory(int id);
}
