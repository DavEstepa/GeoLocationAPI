using GeoLocationDemo.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocationDemo.ApplicationCore.Interfaces.Repositories.PostgreSQL
{
    public interface IListsRepository: IGenericRepository<ListValue>
    {
        public Task<IEnumerable<ListValue>> GetByTypeOfList(string TypeOfListCode);
    }
}
