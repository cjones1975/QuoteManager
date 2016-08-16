using System;


namespace QuoteManager.Dal
{
    public class UnitOfWork : IDisposable
    {
        private readonly QuoteManagerContext dbContext = new QuoteManagerContext();
        private IAccountRepository accountRepository;
        private IQuoteRepository quoteRepository;
        //Product
        private IProductRepository productRepository;
        private ICorporateConnectRepository corporateConnectRepository;

        public IAccountRepository AccountRepository
        {
            get
            {
                if(this.accountRepository == null)
                {
                    this.accountRepository = new AccountRepository(dbContext);
                }
                return accountRepository;
            }
        }

        public IQuoteRepository QuoteRepository
        {
            get
            {
                if (this.quoteRepository == null)
                {
                    this.quoteRepository = new QuoteRepository(dbContext);
                }
                return quoteRepository;
            }
        }



        //Products
        public IProductRepository ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new ProductRepository(dbContext);
                }
                return productRepository;
            }
        }
        public ICorporateConnectRepository CorporateConnectRepository
        {
            get
            {
                if (this.corporateConnectRepository == null)
                {
                    this.corporateConnectRepository = new CorporateConnectRepository(dbContext);
                }
                return corporateConnectRepository;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        // Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
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