using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Js.ContactsViewer.Shared.Models;

public class SubCategory : BaseModel
{
    public SubCategory()
    {
        Contacts = new HashSet<Contact>();
    }

    [Required(ErrorMessage ="Pole nazwa jest wymagane")]
    [MaxLength(50, ErrorMessage ="Dłogość maksymalna pola to 50 znaków")]
    public string SubCatName { get; set; } = string.Empty;
    [MaxLength(250, ErrorMessage = "Dłogość maksymalna pola to 250 znaków")]
    public string SubCatDescription { get; set; } = string.Empty;
    public bool IsManualyEditAvail { get; set; } = false;

    [JsonIgnore]
    public virtual ICollection<Contact> Contacts { get; set; }
}
