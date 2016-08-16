using System;
using System.Linq;
using QuoteManager.Models.Database.Quote;
using QuoteManager.Models.Database.Product;
using System.Data.Entity;

namespace QuoteManager.Dal
{
    public class QuoteRepository : IQuoteRepository, IDisposable
    {
         private readonly QuoteManagerContext dbContext;

        public QuoteRepository(QuoteManagerContext  context)
        {
            dbContext = context;
        }

        public IQueryable<tbl_quotetype> GetQuoteType()
        {
            return dbContext.QuoteType;
        }

        public IQueryable<tbl_quotestatus> GetQuoteStatus()
        {
            return dbContext.QuoteStatus;
        }

        public IQueryable<tbl_quote> GetQuotesByParam(int folderId, int userId)
        {
            return dbContext.Quote.Where(x => x.folderId == folderId && x.userId == userId);
        }

        public IQueryable<tbl_quote> GetQuotesByFolder(int folderId)
        {
            return dbContext.Quote.Where(x => x.folderId == folderId);
        }

        public tbl_quote GetQuoteByID(int quoteId)
        {
            return dbContext.Quote.First(x => x.quoteId == quoteId);
        }

        public void AddQuote(tbl_quote quote)
        {
            dbContext.Quote.Add(quote);
        }
        public void UpdateQuote(tbl_quote quote)
        {
            dbContext.Entry(quote).State = EntityState.Modified;
        }
        public void DeleteQuote(int quoteId)
        {
            tbl_quote quote = dbContext.Quote.First(x => x.quoteId == quoteId);
            dbContext.Quote.Remove(quote);
        }

        #region Folder

        public IQueryable<tbl_quotefolder> GetFoldersByUser(int userId)
        {
            return dbContext.Folder.Where(x => x.userId == userId);
        }

        public tbl_quotefolder GetFolderByID(int folderId)
        {
            return dbContext.Folder.First(x => x.folderId == folderId);
        }

        public void InsertFolder(tbl_quotefolder folder)
        {
            dbContext.Folder.Add(folder);
        }

        public void UpdateFolder(tbl_quotefolder folder)
        {
            dbContext.Entry(folder).State = EntityState.Modified;
        }

        public void DeleteFolder(tbl_quotefolder folder)
        {
            dbContext.Entry(folder).State = EntityState.Deleted;
        }

        #endregion // Folder

        public IQueryable<tbl_customer> GetCustomer()
        {
            return dbContext.Customer;
        }

        public IQueryable<tbl_currency> GetCurrency()
        {
            return dbContext.Currency;
        }

        public IQueryable<tbl_productfamily> GetProductFamily()
        {
            return dbContext.ProductFamily;
        }

        public IQueryable<tbl_productgroup> GetProductGroup(int id)
        {
            return dbContext.ProductGroup.Where(x => x.productFamilyId == id);
        }

        public IQueryable<tbl_product> GetProductByGroupId(int id)
        {
            return dbContext.Product.Where(x => x.productGroupId == id);
        }

        public IQueryable<tbl_product> GetProducts()
        {
            return dbContext.Product;
        }

        // Assigned Products
        public IQueryable<tbl_assignedproducts> GetAssignedProducts(int quoteId)
        {
            return dbContext.AssignedProducts.Where(x => x.quoteId == quoteId);
        }

        public tbl_assignedproducts GetAssignedProductByID(int assignedproductId)
        {
            return dbContext.AssignedProducts.First(x => x.assignedProductId == assignedproductId);
        }

        public void InsertAssignedProduct(tbl_assignedproducts assignedproduct)
        {
            dbContext.AssignedProducts.Add(assignedproduct);
        }

        public void UpdateAssignedProduct(tbl_assignedproducts assignedproduct)
        {
            dbContext.Entry(assignedproduct).State = EntityState.Modified;
        }

        public void DeleteAssignedProduct(int assignedproductId)
        {
            tbl_assignedproducts assignedproduct = dbContext.AssignedProducts.First(x => x.assignedProductId == assignedproductId);
            dbContext.AssignedProducts.Remove(assignedproduct);
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