using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ExceptionManager : Exception
    {
        public ExceptionManager(string message) : base(message) { }
        public ExceptionManager(string message, Exception innerException) : base(message, innerException) { }
    }
}
