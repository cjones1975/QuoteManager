using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using QuoteManager.Models.Database.Account;
using QuoteManager.Models.Database.Quote;
using QuoteManager.Models.Database.Product;

namespace QuoteManager.Dal
{
    public class QuoteManagerContext : DbContext
    {
        // Account
        public DbSet<tbl_users> User { get; set; }

        // Folder
        public DbSet<tbl_quotefolder> Folder { get; set; }

        // Quote
        public DbSet<tbl_quote> Quote { get; set; }
        public DbSet<tbl_quotetype> QuoteType { get; set; }
        public DbSet<tbl_quotestatus> QuoteStatus { get; set; }
        public DbSet<tbl_customer> Customer { get; set; }
        public DbSet<tbl_currency> Currency { get; set; }

        // Product
        public DbSet<tbl_productfamily> ProductFamily { get; set; }
        public DbSet<tbl_productgroup> ProductGroup { get; set; }
        public DbSet<tbl_product> Product { get; set; }
        public DbSet<tbl_assignedproducts> AssignedProducts { get; set; }


    }
}