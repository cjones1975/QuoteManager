using System;
using System.Linq;
using QuoteManager.Models.Database.Account;

namespace QuoteManager.Dal
{
    public interface IAccountRepository : IDisposable
    {
        // User
        tbl_users GetUserById(int userId);
    }
}