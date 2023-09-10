namespace Js.ContactsViewer.Shared.Models;

public class UserSession
{
    public string UserName { get; set; }
    public string Token { get; set; }
    public Role Role { get; set; }
    public int ExpiresIn { get; set; }
    public DateTime ExpiryTimeStamp { get; set; }
}
