using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAchivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        [Route("GetData")]
        public IActionResult GetData()
        {
            string data = "Hello, this is a demo API response!";

            return Ok(data);
        }
    }
}
