using System;
using System.Linq;
using QuoteManager.Models.Database.Product.SitaConnect;
using System.Data.Entity;

namespace QuoteManager.Dal
{
    public class CorporateConnectRepository : ICorporateConnectRepository, IDisposable
    {
        private readonly QuoteManagerContext dbContext;

        public CorporateConnectRepository(QuoteManagerContext context)
        {
            dbContext = context;
        }

        public IQueryable<tbl_corporateconnect> GetCorporateConnects(int assignedProductId)
        {
            return dbContext.CorporateConnect.Where(x => x.assignedProductId == assignedProductId);
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