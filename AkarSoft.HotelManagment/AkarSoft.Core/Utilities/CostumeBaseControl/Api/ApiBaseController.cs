using AkarSoft.Core.Utilities.Result.Api;
using Microsoft.AspNetCore.Mvc;

namespace AkarSoft.Core.Utilities.CostumeBaseControl.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ApiResponseDto<T> Response) // response a göre ilgili dönüşler sağlanacaktır. 
        {
            if (Response.StatusCode == 204) // No Content (delete / Update)
            {
                return new ObjectResult(null) { StatusCode = Response.StatusCode }; // OK Bad request gibi dönmeme gerek yok Object result ta datayı null yaptık 
                // her seferinde tek tek dönmemize gerek kalmadı
            }
            return new ObjectResult(Response) { StatusCode = Response.StatusCode };
        }
    }
}
