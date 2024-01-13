using Apka_Kursy.Entities;
using Apka_Kursy.Models;

namespace Apka_Kursy.Services
{
    public interface IBuyCourseService
    {
        void CreateTransaction(BuyCourseDto dto);

    }
    public class BuyCourseService : IBuyCourseService
    {
        private readonly Apka_KursyDBContext _context;

        public BuyCourseService(Apka_KursyDBContext context)
        {
            _context = context;
        }

        public void CreateTransaction(BuyCourseDto dto)
        {
            var buyCourse = new BuyCourse
            {
                Id = dto.Id,
                UserId = dto.UserId,
                AmountPaid = dto.AmountPaid,
                CourseId = dto.CourseId,
                PurchaseDate = DateTime.Now,
                BuyingStatus = dto.BuyingStatus,

            };

            _context.BuyCourse.Add(buyCourse);
            _context.SaveChanges();
        }


    }
}