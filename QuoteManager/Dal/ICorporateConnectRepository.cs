using System;
using System.Linq;
using QuoteManager.Models.Database.Product.SitaConnect;

namespace QuoteManager.Dal
{
    public interface ICorporateConnectRepository : IDisposable
    {
        IQueryable<tbl_corporateconnect> GetCorporateConnects(int assignedProductId);
        tbl_corporateconnect GetCorporateConnectById(int corporateConnectId);
        bool HasCorporateConnects(int assignedProductId);
        void AddCorporateConnect(tbl_corporateconnect corporateconnect);
        void UpdateCorporateConnect(tbl_corporateconnect corporateconnect);
   }
}