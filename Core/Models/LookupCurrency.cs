
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class LookupCurrency : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LookupCurrencyId { get; set; }

        public string LookupCurrencyCurrencyCode { get; set; }

        public decimal LookupCurrencyConversionRateToUSD { get; set; }

    }
}
