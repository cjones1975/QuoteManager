using System;
using System.Linq;
using QuoteManager.Models.Database.Quote;
using QuoteManager.Models.Database.Product;

namespace QuoteManager.Dal
{
    public interface IQuoteRepository : IDisposable
    {
        IQueryable<tbl_quote> GetQuotesByParam(int folderId, int userId);
        tbl_quote GetQuoteByID(int quoteId);
        IQueryable<tbl_quote> GetQuotesByFolder(int folderId);
        IQueryable<tbl_quotetype> GetQuoteType();
        IQueryable<tbl_quotestatus> GetQuoteStatus();
        void AddQuote(tbl_quote quote);
        void UpdateQuote(tbl_quote quote);
        void DeleteQuote(int quoteId);
        // Quote Folder
        IQueryable<tbl_quotefolder> GetFoldersByUser(int userId);
        tbl_quotefolder GetFolderByID(int folderId);
        void InsertFolder(tbl_quotefolder folder);
        void UpdateFolder(tbl_quotefolder folder);
        void DeleteFolder(tbl_quotefolder folder);
        // End Quote Folders
        IQueryable<tbl_customer> GetCustomer();
        IQueryable<tbl_currency> GetCurrency();
        IQueryable<tbl_productfamily> GetProductFamily();
        IQueryable<tbl_productgroup> GetProductGroup(int id);
        IQueryable<tbl_product> GetProductByGroupId(int id);
        IQueryable<tbl_product> GetProducts();
        IQueryable<tbl_assignedproducts> GetAssignedProducts(int quoteId);
        void InsertAssignedProduct(tbl_assignedproducts assignedproduct);
        void UpdateAssignedProduct(tbl_assignedproducts assignedproduct);
        void DeleteAssignedProduct(int assignedproductId);

       
    }
}
