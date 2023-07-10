using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoLocationDemo.ApplicationCore.Entities
{
    public class ListValue
    {
        public Guid Id { get; set; }
        public string MessageToShow { get; set; }
        public int Code { get; set; }
        public string TypeOfListCode { get; set; }
        public string TypeOfListValue { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
