using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoLocationDemoAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        private readonly ILogger<GenericController> _logger;

        public GenericController(ILogger<GenericController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        public string MethodExample()
        {
            return "OK";
        }

    }
}
