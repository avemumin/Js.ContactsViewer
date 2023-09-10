namespace Js.ContactsViewer.Shared.Models
{

    public class UserAccount : BaseModel
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
