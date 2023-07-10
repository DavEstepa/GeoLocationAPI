using Dapper;
using GeoLocationDemo.ApplicationCore.Interfaces.Repositories.PostgreSQL;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocationDemo.Infrastructure.Repositories.PostgreSQL.Helpers
{
    public static class Extensions
    {
        public static void AddOutputs(this DynamicParameters parameters, string[] refCursors)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }
            foreach (string refCursorName in refCursors)
            {
                parameters.Add(refCursorName, dbType: DbType.Object, direction: ParameterDirection.Output);
            }
            
        }

        public static async Task<IEnumerable<T>> RetrieveCursorValues<T>(this NpgsqlConnection connection, string cursorReference)
        {
            var query = $"FETCH ALL IN \"{cursorReference}\";";
            return await connection.QueryAsync<T>(query);

        }
    }
}
