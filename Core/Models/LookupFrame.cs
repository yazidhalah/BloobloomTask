
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class LookupFrame : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LookupFrameId { get; set; }
        public string LookupFrameName { get; set; }
        public string LookupFrameDescription { get; set; }
        public int LookupFrameStock { get; set; }
        public decimal LookupFramePrice { get; set; }
    }
}
