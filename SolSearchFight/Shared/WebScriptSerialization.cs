using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Shared
{
    public class WebScriptSerialization
    {
    }

    public static class StringExtensions
    {
        public static T DeserializeJson<T>(this string json)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            return javaScriptSerializer.Deserialize<T>(json);
        }
    }
}
