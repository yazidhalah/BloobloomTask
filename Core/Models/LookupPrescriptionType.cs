

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class LookupPrescriptionType : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LookupPrescriptionTypeId { get; set; }

        public string LookupPrescriptionTypeName { get; set; }

    }
}
