using System;
using System.Linq;
using QuoteManager.Models.Database.Account;

namespace QuoteManager.Dal
{
    public class AccountRepository : IAccountRepository, IDisposable
    {
        private readonly QuoteManagerContext dbContext;

        public AccountRepository(QuoteManagerContext  context)
        {
            dbContext = context;
        }

        public tbl_users GetUserById(int userId)
        {
            return dbContext.User.First(x => x.userId == userId);
        }

        // Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}