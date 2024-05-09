
namespace Core.Models
{
    public class BaseEntity
    {
        public StatusEnum Status { get; set; }

        public enum StatusEnum
        {
            Active = 1,
            InActive = 2,
            Deleted = 4,
           
            Entered = 5,
            Approved = 10,
        }

        public int? CreateId { get; set; }
        public DateTime? CreateDate { get; set; }

        public int? EditId { get; set; }

        public DateTime? EditDate { get; set;}
    }
}
