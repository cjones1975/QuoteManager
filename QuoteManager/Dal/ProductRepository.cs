using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuoteManager.Models.Database.Product;

namespace QuoteManager.Dal
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private readonly QuoteManagerContext dbContext;

        public ProductRepository(QuoteManagerContext context)
        {
            dbContext = context;
        }

        public IQueryable<tbl_country> GetCountries()
        {
            return dbContext.Countries;
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