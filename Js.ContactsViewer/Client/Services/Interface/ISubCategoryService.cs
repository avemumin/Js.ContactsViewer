namespace Js.ContactsViewer.Client.Services.Interface;

public interface ISubCategoryService
{
    List<SubCategory> SubCategories { get; set; }
    SubCategory SubCategory {get;set;}
    Task GetSubCategories();
    Task GetSubCategoryById(int id);



    Task CreateSubCategory(SubCategory subCategory);
    Task UpdateSubCategory(SubCategory subCategory);
    Task DeleteSubCategory(int id);
}
