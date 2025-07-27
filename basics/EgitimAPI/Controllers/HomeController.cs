using Microsoft.AspNetCore.Mvc;
using EgitimAPI.Models;

namespace EgitimAPI.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessage()
        {
            var result =  new ResponseModel()
            {
                HttpStatus = 200,
                Message = "Hello ASP .NET Core Web API"
            };

            return Ok(result);
        }
    }
}
