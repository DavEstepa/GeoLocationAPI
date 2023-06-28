using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocationDemo.ApplicationCore.Interfaces.Repositories.PostgreSQL
{
    public interface IListsRepository
    {
        public Task<string> GenericMethod();
    }
}
