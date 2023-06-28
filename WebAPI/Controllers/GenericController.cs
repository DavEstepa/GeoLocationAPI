using GeoLocationDemo.ApplicationCore.Interfaces.Repositories.PostgreSQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoLocationDemoAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        private readonly ILogger<GenericController> _logger;
        private readonly IListsRepository _listsRepository;

        public GenericController(ILogger<GenericController> logger, IListsRepository listsRepository)
        {
            this._logger = logger;
            this._listsRepository = listsRepository;
        }

        [HttpGet]
        public async Task<string> MethodExample()
        {
            return await this._listsRepository.GenericMethod();
        }

    }
}
