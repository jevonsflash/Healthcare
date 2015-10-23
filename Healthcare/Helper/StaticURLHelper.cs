using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Helper
{
    public static class StaticURLHelper
    {
        public static string DiseaseShow = "http://www.tngou.net/api/disease/show";
        public static string DiseaseShowByPlace = "http://www.tngou.net/api/disease/place";
        public static string DiseaseShowByDepartment = "http://www.tngou.net/api/disease/department";
        public static string SymptomShow = "http://www.tngou.net/api/symptom/show";
        public static string SymptomShowByPlace = "http://www.tngou.net/api/symptom/place";
        public static string SymptomShowByDepartment = "http://www.tngou.net/api/symptom/department";

        public static string[] GetURL(string typeName)

        {
            string[] sResult = new string[5];
            switch (typeName)
            {
                case "Symptom":
                    sResult[0] = StaticURLHelper.SymptomShow;
                    sResult[1] = StaticURLHelper.SymptomShowByPlace;
                    sResult[2] = StaticURLHelper.SymptomShowByDepartment;
                    break;
                case "Disease":
                    sResult[0] = StaticURLHelper.DiseaseShow;
                    sResult[1] = StaticURLHelper.DiseaseShowByPlace;
                    sResult[2] = StaticURLHelper.DiseaseShowByDepartment;
                    break;
                default: break;

            }
            return sResult;
        }
    }
}
