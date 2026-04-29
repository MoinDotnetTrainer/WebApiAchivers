using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAchivers.Controllers.Version1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Values")]
    [ApiVersion("1.0")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Products from API v1");
        }
    }
}
