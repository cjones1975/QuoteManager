using System;
using System.Linq;
using QuoteManager.Models.Database.Product;

namespace QuoteManager.Dal
{
    public interface IProductRepository : IDisposable
    {
        IQueryable<tbl_country> GetCountries();
        IQueryable<tbl_serviceNet> GetServiceNets();
    }
}
