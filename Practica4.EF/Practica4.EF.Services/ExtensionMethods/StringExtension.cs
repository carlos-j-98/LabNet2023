using Newtonsoft.Json;
using System.Collections.Generic;

namespace Practica4.EF.Services.ExtensionMethods
{
    public static class StringExtension
    {
        public static string ToJSON(this string value)
        {
            return JsonConvert.SerializeObject(new { value });
        }
        public static string ToJSONList(this List<object> list)
        {
            return JsonConvert.SerializeObject(list);
        }
    }
}
