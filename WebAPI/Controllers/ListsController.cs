using GeoLocationDemo.ApplicationCore.Entities;
using GeoLocationDemo.ApplicationCore.Interfaces.Repositories.PostgreSQL;
using GeoLocationDemoAPI.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoLocationDemoAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ListsController : BaseController
    {
        private readonly ILogger<ListsController> _logger;
        private readonly IListsRepository _listsRepository;

        public ListsController(ILogger<ListsController> logger, IListsRepository listsRepository)
        {
            this._logger = logger;
            this._listsRepository = listsRepository;
        }

        [HttpGet]
        public async Task<Response<IEnumerable<ListValue>>> MethodExample(string TypeOfListCode)
        {
            var response = await this._listsRepository.GetByTypeOfList(TypeOfListCode);
            return ResponseWrapper(true, response, "");
        }

    }
}
