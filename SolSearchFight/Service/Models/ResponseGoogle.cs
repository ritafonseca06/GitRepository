using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class ResponseGoogle
    {
        public string TypeEngine { get; set; }
        public GoogleSearchInfo SearchInformation { get; set; }
    }
}
