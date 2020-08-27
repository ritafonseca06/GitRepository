using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Shared
{
    public class GeneralConfiguration
    {
        public static string GoogleUrl => ConfigurationManager.AppSettings["urlGoogle"];
        public static string BingUrl => ConfigurationManager.AppSettings["urlBing"];

        public static string BingKey => ConfigurationManager.AppSettings["BingKey"];
        public static string GoogleKey => ConfigurationManager.AppSettings["GoogleAPIKey"];
        public static string GoogleCEKey => ConfigurationManager.AppSettings["GoogleCEKey"];        
    }
}
