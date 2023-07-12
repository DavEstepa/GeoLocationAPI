using GeoLocationDemoAPI.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeoLocationDemoAPI.WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        protected Response<T> ResponseWrapper<T>(bool success, T data, string message = null)
        {
            var response = new GeneralResponse<T>
            {
                Success = success,
                Data = data,
                Message = message
            };

            return new Response<T>(response);
        }
    }
}
