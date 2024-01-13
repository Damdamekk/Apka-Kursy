using System.ComponentModel.DataAnnotations.Schema;

namespace Apka_Kursy.Entities
{
    public class BuyCourse
    {
        internal object BuyingStatus;

        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmountPaid { get; set; }
        public DateTime PurchaseDate { get; set; }
        public BuyingStatus Status { get; set; }
    }
    public enum BuyingStatus
    {
        Pending,
        Accepted,
        Rejected,
        Withdrawn
    }
}
