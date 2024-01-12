using Apka_Kursy.Models;
using Apka_Kursy.Entities;
using Microsoft.AspNetCore.Identity;
using Apka_Kursy.Exceptions;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Apka_Kursy.Services
{
    public class AccountService : IAccountService
    {
        private readonly Apka_KursyDBContext _context;
        private readonly IPasswordHasher<Users> _passwordHasher;
        private AuthenticationSettings _authenticationSettings;

        public AccountService(Apka_KursyDBContext context, IPasswordHasher<Users> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public void RegisterUser(RegisterUserDto dto) 
        {
            var newUser = new Users()
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.FirstName,
                RoleId = dto.RoleId,
                Password_hash = dto.Password,

            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);

            newUser.Password_hash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        
        string IAccountService.GenerateJwt(LoginDto dto)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == dto.Email);

            if(user is null)
            {
                throw new BadRequestException("Invalid Email or Password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password_hash, dto.Password);

            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid Email or Password");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials : cred);
            
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
