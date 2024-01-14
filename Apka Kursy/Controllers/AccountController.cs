using Apka_Kursy.Exceptions;
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
            try 
            { 
                _accountService.RegisterUser(dto);
                return Ok();
            } 
            catch (AccountAlreadyExistsException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)//Akcja logowania
        {
            try 
            { 
                string token = _accountService.GenerateJwt(dto);
                return Ok(token);
            } 
            catch (InvalidCredentialsException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
