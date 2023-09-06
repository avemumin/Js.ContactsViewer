using System.Text.Json.Serialization;

namespace Js.ContactsViewer.Shared.Models;

public class Category : BaseModel
{

    public Category()
    {
        Contacts = new HashSet<Contact>();
    }
    public string CategoryName { get; set; } = string.Empty;
    public string CategoryDescription { get; set; } = string.Empty;
    [JsonIgnore]
    public virtual ICollection<Contact> Contacts { get; set; }
}

