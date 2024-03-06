using Microsoft.AspNetCore.Mvc;

namespace AkarSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Deneme()
        {
            return Ok("Test edildi. Çalışıyor ");
        }
    }
}
