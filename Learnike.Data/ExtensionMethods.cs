using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Learnike
{
    public static class ExtensionMethods
    {
        public static T Clone<T>(this T toClone) 
            where T : class
        {
            string tmp = JsonConvert.SerializeObject(toClone);
            return JsonConvert.DeserializeObject<T>(tmp);
        }
    }
}
