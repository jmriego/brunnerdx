using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunnerDX.Mapping
{
    public class ButtonMapping
    {
        public static string[] listMappings = { "DecTrimX", "IncTrimX", "DecTrimY", "IncTrimY", "CenterTrim" };

        public static Dictionary<string, int> GenerateMapping()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (string buttonName in listMappings)
            {
                result[buttonName] = -1;
            }
            return result;
        }
    }
}
