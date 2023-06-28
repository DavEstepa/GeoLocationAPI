using Dapper;
using GeoLocationDemo.ApplicationCore.Interfaces.Repositories.PostgreSQL;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocationDemo.Infrastructure.Repositories.PostgreSQL
{
    public class ListRepository : IListsRepository
    {
        private NpgsqlConnection connection;
        public async Task<string> GenericMethod()
        {
            string CONNECTION_STRING = "Host=localhost:port;" +
                                        "Username=user;" +
                                        "Password=password;" +
                                        "Database=GeoLocationDemo";
            string TABLE_NAME = "masters.lists";
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();

            string commandText = $"SELECT * FROM {TABLE_NAME}";
            var games = await connection.QueryAsync(commandText);

            connection.Close();
            return "OK";
        }
    }
}
