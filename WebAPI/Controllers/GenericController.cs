using GeoLocationDemo.ApplicationCore.Entities;
using GeoLocationDemo.ApplicationCore.Interfaces.Repositories.PostgreSQL;
using GeoLocationDemoAPI.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoLocationDemoAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class GenericController : BaseController
    {
        private readonly ILogger<GenericController> _logger;
        private readonly IListsRepository _listsRepository;

        public GenericController(ILogger<GenericController> logger, IListsRepository listsRepository)
        {
            this._logger = logger;
            this._listsRepository = listsRepository;
        }

        [HttpGet]
        public async Task<Response<IEnumerable<ListValue>>> MethodExample(string TypeOfListCode)
        {
            throw new Exception("Intended Exception");
            var response = await this._listsRepository.GetByTypeOfList(TypeOfListCode);
            return ResponseWrapper(true, response, "");
        }

    }
}
