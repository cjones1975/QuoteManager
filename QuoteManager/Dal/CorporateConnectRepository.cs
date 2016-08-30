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

        public void UpdateCorporateConnect(tbl_corporateconnect corporateconnect)
        {
            dbContext.Entry(corporateconnect).State = EntityState.Modified;
        }

        public IQueryable<tbl_corporateconnect> GetCorporateConnects(int assignedProductId)
        {
            return dbContext.CorporateConnect.Where(x => x.assignedProductId == assignedProductId);
        }

        public tbl_corporateconnect GetCorporateConnectById(int corporateConnectId)
        {
            return dbContext.CorporateConnect.First(x => x.corporateConnectId == corporateConnectId);
        }

        public bool HasCorporateConnects(int assignedProductId)
        {
            return dbContext.CorporateConnect.Where(x => x.assignedProductId == assignedProductId).Any();
        }

        public void AddCorporateConnect(tbl_corporateconnect corporateconnect)
        {
            dbContext.CorporateConnect.Add(corporateconnect);
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