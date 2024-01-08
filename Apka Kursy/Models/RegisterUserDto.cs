using System.ComponentModel.DataAnnotations;

namespace Apka_Kursy.Models
{
    public class RegisterUserDto
    {
        
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }

        public int RoleId { get; set; } = 2;
    }
}
