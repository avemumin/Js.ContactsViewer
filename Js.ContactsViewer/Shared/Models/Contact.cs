namespace Js.ContactsViewer.Shared.Models;

/// <summary>
/// Klasa opisujaca kontakt dziedziczy po klasie BaseModel
/// </summary>
public class Contact : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime? BirthDay { get; set; } 


    public Category? Category { get; set; }
    public int? CategoryId { get; set; }

    public SubCategory? SubCategory { get; set; }
    public int? SubCategoryId { get; set; }
}

