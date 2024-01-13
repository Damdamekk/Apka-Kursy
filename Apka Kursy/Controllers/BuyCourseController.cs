using Apka_Kursy.Models;
using Apka_Kursy.Services;
using Microsoft.AspNetCore.Mvc;

namespace Apka_Kursy.Controllers
{
    [Route("api/buy")]
    [ApiController]
    public class BuyCourseController : ControllerBase
    {
        private readonly IBuyCourseService _buyService;
        public BuyCourseController(IBuyCourseService buyService)
        {
            _buyService = buyService;
        }

        [HttpGet("api/buycourse")]
        public async Task<ActionResult> CreateTransaction([FromBody] BuyCourseDto dto)
        {
            try
            {
                await _buyService.CreateTransaction(dto);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
