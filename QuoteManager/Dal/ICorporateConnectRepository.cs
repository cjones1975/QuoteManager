using System;
using System.Linq;
using QuoteManager.Models.Database.Product.SitaConnect;

namespace QuoteManager.Dal
{
    public interface ICorporateConnectRepository : IDisposable
    {
        IQueryable<tbl_corporateconnect> GetCorporateConnects(int assignedProductId);
    }
}