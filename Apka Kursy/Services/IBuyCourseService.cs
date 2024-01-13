using Apka_Kursy.Models;

namespace Apka_Kursy.Services;

public interface IBuyCourseService
{
    Task<bool> CreateTransaction(BuyCourseDto dto);
}