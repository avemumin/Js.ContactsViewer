using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Js.ContactsViewer.Shared.Models;

public class Category : BaseModel
{

    public Category()
    {
        Contacts = new HashSet<Contact>();
    }
    [Required(ErrorMessage = "Pole nazwa jest wymagane")]
    [MaxLength(50, ErrorMessage = "Dłogość maksymalna pola to 50 znaków")]


    public string CategoryName { get; set; } = string.Empty;
    [MaxLength(250, ErrorMessage = "Dłogość maksymalna pola to 250 znaków")]
    public string CategoryDescription { get; set; } = string.Empty;
    [JsonIgnore]
    public virtual ICollection<Contact> Contacts { get; set; }
}

