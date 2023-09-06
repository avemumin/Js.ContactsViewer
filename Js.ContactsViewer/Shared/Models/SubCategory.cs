namespace Js.ContactsViewer.Shared.Models;

public class SubCategory : BaseModel
{
    public SubCategory()
    {
        Contacts = new HashSet<Contact>();
    }

    public string SubCatName { get; set; } = string.Empty;
    public string SubCatDescription { get; set; } = string.Empty;
    public bool IsManualyEditAvail { get; set; } = false;

    public virtual ICollection<Contact> Contacts { get; set; }
}
