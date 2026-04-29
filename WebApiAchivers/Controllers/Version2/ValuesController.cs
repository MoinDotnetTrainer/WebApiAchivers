using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAchivers.Controllers.Version2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Values")]
    [ApiVersion("2.0")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Products from API v2");
        }
    }
}
