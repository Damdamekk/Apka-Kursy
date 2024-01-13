using Apka_Kursy.Entities;
using Apka_Kursy.Exceptions;
using Apka_Kursy.Models;

namespace Apka_Kursy.Services
{
    public class BuyCourseService : IBuyCourseService
    {
        private readonly Apka_KursyDBContext _context;

        public BuyCourseService(Apka_KursyDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTransaction(BuyCourseDto dto)
        {
            var buyCourse = new BuyCourse
            {
                Id = dto.Id,
                UserId = dto.UserId,
                AmountPaid = dto.AmountPaid,
                CourseId = dto.CourseId,
                PurchaseDate = DateTime.Now.ToUniversalTime(),
                BuyingStatus = dto.BuyingStatus,
            };

            _context.BuyCourse.Add(buyCourse);
           var savingResult =  await _context.SaveChangesAsync();

           if (savingResult <= 0)
               throw new DatabaseSavingException("There was a problem to save transaction to database");

           return true;
        }
    }
}