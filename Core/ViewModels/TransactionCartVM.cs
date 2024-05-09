using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class TransactionCartVM
    {
        public int TransactionCartId { get; set; }
        public int TransactionCartUserId { get; set; }
        public int LookupFrameId { get; set; }
        public int LookupLensId { get; set; }
        public DateTime TransactionCartDate { get; set; }
        public int LookupCurrencyId { get; set; }
        public int TransactionCartQuantity { get; set; }
    }
}
