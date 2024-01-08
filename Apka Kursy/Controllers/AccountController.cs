using Apka_Kursy.Models;
using Apka_Kursy.Services;
using Microsoft.AspNetCore.Mvc;

namespace Apka_Kursy.Controllers

{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) 
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)//Akcja rejestracji
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)//Akcja logowania
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
