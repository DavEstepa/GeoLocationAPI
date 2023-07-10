using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocationDemo.ApplicationCore.Constants.Infrastructure
{
    public static class AppSettingsValues
    {
        public static string PostgreConnection { get; private set; } = "ConnectionStrings:PostgreSQL";
    }
}
