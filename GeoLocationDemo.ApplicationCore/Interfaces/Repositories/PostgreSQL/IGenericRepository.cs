using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocationDemo.ApplicationCore.Interfaces.Repositories.PostgreSQL
{
    public interface IGenericRepository<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetByCode(string Code);
        public Task<T> Delete(string Code);
        public Task<T> Update(string Code);
    }
}
