using Healthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Helper
{
    public class FilterHelper
    {
        public static string[] GetFilterName(string typeName)
        {
            string[] result = new string[2];
            switch (typeName)
            {
                case "Symptom":
                case "Disease":
                case "Check":
                case "Operation":
                    result[0] = "Body|部位";
                    result[1] = "Department|科室";
                    break;
            }
            return result;
        }
    }
}
