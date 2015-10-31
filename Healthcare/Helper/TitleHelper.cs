using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Helper
{
    public class TitleHelper
    {
        public static Dictionary<string, string> Title
        {
            get
            {
                Dictionary<string, string> temp = new Dictionary<string, string>();
                temp.Add("Disease", "疾病");
                temp.Add("Symptom", "病状");
                temp.Add("Operation", "手术");
                temp.Add("Check", "体检");
                return temp;
            }
        }
        public static string GetTitle(string key)
        {
            if (Title.Keys.Contains(key))
            {
                return Title[key];
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
