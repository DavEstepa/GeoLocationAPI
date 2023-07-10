using Dapper;
using GeoLocationDemo.ApplicationCore;
using GeoLocationDemo.ApplicationCore.Entities;
using GeoLocationDemo.ApplicationCore.Interfaces.Repositories.PostgreSQL;
using GeoLocationDemo.Infrastructure.Repositories.PostgreSQL.Helpers;
using GeoLocationDemo.ApplicationCore.Constants.Infrastructure;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace GeoLocationDemo.Infrastructure.Repositories.PostgreSQL
{
    public class ListRepository : IListsRepository
    {
        private readonly IConfiguration _configuration;

        public ListRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<ListValue> Delete(string Code)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ListValue>> GetByTypeOfList(string TypeOfListCode)
        {
            string? CONNECTION_STRING = _configuration.GetRequiredSection(AppSettingsValues.PostgreConnection).Value;
            IEnumerable<ListValue> results;
            var connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();

            using (var tran = connection.BeginTransaction())
            {
                var parameters = new DynamicParameters();
                parameters.Add("typeoflistcodevalue", TypeOfListCode);
                string[] outputParams = StoredProcedures.GetListByTypelistCode<string[]>();
                parameters.AddOutputs(outputParams);

                await connection.QueryAsync(StoredProcedures.GetListByTypelistCode<string>(),
                                            parameters,
                                            commandType: CommandType.StoredProcedure);

                results = await connection.RetrieveCursorValues<ListValue>(parameters.Get<string>(outputParams[0]));

                tran.Commit();
            }
            connection.Close();
            return results;
        }

        public Task<IEnumerable<ListValue>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ListValue> GetByCode(string Code)
        {
            throw new NotImplementedException();
        }

        public Task<ListValue> Update(string Code)
        {
            throw new NotImplementedException();
        }
    }
}
