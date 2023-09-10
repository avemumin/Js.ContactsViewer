using Js.ContactsViewer.Shared.Utility;
using System.ComponentModel.DataAnnotations;

namespace Js.ContactsViewer.Shared.Models;

/// <summary>
/// Klasa opisujaca kontakt dziedziczy po klasie BaseModel
/// </summary>
public class Contact : BaseModel
{
    [Required(ErrorMessage ="Pole imię jest wymagane"),MaxLength(50,ErrorMessage ="Maksymalna długość dla imnienia to 50 znaków")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Pole nazwisko jest wymagane"), MaxLength(70, ErrorMessage = "Maksymalna długość dla nazwiska to 70 znaków")]
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage ="Hasło musi mieć minimum 8 znaków")]
    [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Hasło musi posiadać minimum 8 znaków i zawierac  3 z 4 zakresów: duże litery A-Z, małe litery a-z, liczby 0-9 !@#$%^&*")]
    public string Password { get; set; } = string.Empty;
    [MaxLength(17, ErrorMessage ="Nr telefonu nie może mieć więcej niż 17 znaków")]
    public string Phone { get; set; } = string.Empty;
    [BirthDayExtension(ErrorMessage ="Błędna data")]
    public DateTime? BirthDay { get; set; } 


    public virtual Category? Category { get; set; }
    public int? CategoryId { get; set; }

    public virtual SubCategory? SubCategory { get; set; }
    public int? SubCategoryId { get; set; }
}

