using Apka_Kursy.Models;

namespace Apka_Kursy.Services;

public interface IAccountService
{
    void RegisterUser(RegisterUserDto dto);
    string GenerateJwt(LoginDto dto);
}