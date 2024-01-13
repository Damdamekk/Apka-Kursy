using Apka_Kursy.Entities;
using System;

namespace Apka_Kursy.Models
{
    public class BuyCourseDto
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PurchaseDate { get; set; }
        public BuyingStatus BuyingStatus { get; set; }
    }
}