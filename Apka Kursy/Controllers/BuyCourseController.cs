using Apka_Kursy.Models;
using Apka_Kursy.Services;
using Microsoft.AspNetCore.Mvc;

namespace Apka_Kursy.Controllers
{
    public class BuyCourseController : ControllerBase
    {
        private readonly IBuyCourseService _buyService;
        public BuyCourseController(IBuyCourseService buyService)
        {
            _buyService = buyService;
        }

        [HttpGet("api/buycourse")]
        public IActionResult CreateTransaction([FromBody] BuyCourseDto dto)
        {
            try
            {
                var userId = 1; // Przyjmujemy, że użytkownik jest zalogowany
                _buyService.CreateTransaction(dto);

                return Ok();
            } 
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
