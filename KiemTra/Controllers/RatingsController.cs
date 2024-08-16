using KiemTra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiemTra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRating _service;

        public RatingsController(IRating service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int month, [FromQuery] int year, [FromQuery] int page)
        {
            try
            {
                var listRating = await _service.GetRatingByMonthAsync(month, year,page);

                if (listRating == null || !listRating.Any())
                {
                    return NotFound("Not found");
                }

                return Ok(listRating);
            }
            catch (Exception ex)
            {
                // Log exception if needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
