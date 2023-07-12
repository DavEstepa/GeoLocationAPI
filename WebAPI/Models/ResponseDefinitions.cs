using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GeoLocationDemoAPI.WebAPI.Models
{
    public class Response<T>: ActionResult
    {
        private readonly GeneralResponse<T> _response;
        public Response(GeneralResponse<T> response)
        {
            _response = response;
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_response)
            {
                StatusCode = _response.Success ? (int)HttpStatusCode.OK : (int)HttpStatusCode.BadRequest,
                DeclaredType = typeof(GeneralResponse<T>)
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
