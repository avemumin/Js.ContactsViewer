using Js.ContactsViewer.Server.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Js.ContactsViewer.Server.Authentication
{
    public class UserAccountService 
    {
        private readonly ApplicationDbContext _dbContext;

        public UserAccountService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public UserAccount? GetUserAccountByUserName(string userName)
        {
            var user = _dbContext.UserAccounts
                .Include(r=>r.Role)
                .FirstOrDefault(u => u.UserName == userName);
            return user;
        }
    }
}
