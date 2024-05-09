using Core;
using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Entity
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

      

        public IBaseRepository<LookupFrame> LookupFrameService {  get; }

        public IBaseRepository<LookupCurrency> LookupCurrencyService { get; }

        public IBaseRepository<LookupLens> LookupLensService { get; }

        public IBaseRepository<TransactionCart> TransactionCartService { get; }

        public UnitOfWork(ApplicationDbContext context,
            IBaseRepository<LookupFrame> lookupFrameService,
            IBaseRepository<LookupCurrency> lookupCurrencyService,
            IBaseRepository<LookupLens> lookupLensService,
            IBaseRepository<TransactionCart> transactionCartService)
        {
            _context = context;
            LookupFrameService = lookupFrameService;
            LookupCurrencyService = lookupCurrencyService;
            LookupLensService = lookupLensService;
            TransactionCartService = transactionCartService;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        } 
       
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
