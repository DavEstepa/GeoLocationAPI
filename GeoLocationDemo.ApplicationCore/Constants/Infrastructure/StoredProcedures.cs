using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocationDemo.ApplicationCore.Constants.Infrastructure
{
    public static class StoredProcedures
    {
        public static T GetListByTypelistCode<T>() {
            return GenericRegister<T>("masters.sp_get_list_by_typelistcode",
                                       new string[] { "p_result"
                                       });
        }

        private static T GenericRegister<T>(string nameProcedure, string[] outputParams)
        {
            if (typeof(T) == typeof(string))
            {
                return (T)(object)nameProcedure;
            }
            else if (typeof(T) == typeof(string[]))
            {
                return (T)(object)outputParams;
            }
            else
            {
                throw new Exception("Unhandle Type. Use only a string or a string[] as Generics");
            }
        }
    }
}
