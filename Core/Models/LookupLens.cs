
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class LookupLens : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LookupLensId { get; set; }
        public string LookupLensColor { get; set; }
        public string LookupLensDescription { get; set; }
        public int LookupLensStock { get; set; }
        public decimal LookupLensPrice { get; set; }


        public int LookupPrescriptionTypeId { get; set; }
        public int LookupLensTypeId { get; set; }

        [ForeignKey(nameof(LookupPrescriptionTypeId))]
        public LookupPrescriptionType? LookupPrescriptionType { get; set; }

        [ForeignKey(nameof(LookupLensTypeId))]
        public LookupLensType? LookupLensType { get; set; }

    }
}
