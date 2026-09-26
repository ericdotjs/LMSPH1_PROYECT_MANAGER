using System;
using Newtonsoft.Json;

namespace LMSPH1_PROYECT_MANAGER.Utils
{
    public static class JSonManager
    {
        public static string SerializeObject(object data)
        {
            return JsonConvert.SerializeObject(data,Formatting.Indented);
        }

        public static T? DeserializeObject<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}