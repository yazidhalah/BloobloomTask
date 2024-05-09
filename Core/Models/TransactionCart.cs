
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class TransactionCart : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionCartId { get; set; }
        public int TransactionCartUserId { get; set; }
        public int LookupFrameId { get; set; }
        public int LookupLensId { get; set; }
        public DateTime TransactionCartDate { get; set; }
        public int LookupCurrencyId { get; set; }
        public int TransactionCartQuantity { get; set; }
        


        [ForeignKey(nameof(LookupFrameId))]
        public LookupFrame? LookupFrame { get; set; }

        [ForeignKey(nameof(LookupLensId))]
        public LookupLens? LookupLens { get; set; }

        [ForeignKey(nameof(LookupCurrencyId))]
        public LookupCurrency? LookupCurrency { get; set; }
    }

 
}
