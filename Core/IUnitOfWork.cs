using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<LookupFrame> LookupFrameService { get; }
        IBaseRepository<LookupCurrency> LookupCurrencyService { get; }
        IBaseRepository<LookupLens> LookupLensService { get; }
        IBaseRepository<TransactionCart> TransactionCartService { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();
       
        int Complete();
    }
}
