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
        public static string CheckShow = "http://www.tngou.net/api/check/show";
        public static string CheckShowByPlace = "http://www.tngou.net/api/check/place";
        public static string CheckShowByDepartment = "http://www.tngou.net/api/check/department";
        public static string CheckShowClassify = "http://www.tngou.net/api/check/list";
        public static string OperationShow = "http://www.tngou.net/api/operation/show";
        public static string OperationShowByPlace = "http://www.tngou.net/api/operation/place";
        public static string OperationShowByDepartment = "http://www.tngou.net/api/operation/department";
        public static string FoodShow = "http://www.tngou.net/api/food/show";



        public static string InfoShow = "http://www.tngou.net/api/info/show";
        public static string InfoList = "http://www.tngou.net/api/info/list";


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
                case "Check":
                    sResult[0] = StaticURLHelper.CheckShow;
                    sResult[1] = StaticURLHelper.CheckShowByPlace;
                    sResult[2] = StaticURLHelper.CheckShowByDepartment;
                    sResult[3] = StaticURLHelper.CheckShowClassify;
                    break;
                case "Operation":
                    sResult[0] = StaticURLHelper.OperationShow;
                    sResult[1] = StaticURLHelper.OperationShowByPlace;
                    sResult[2] = StaticURLHelper.OperationShowByDepartment;
                    break;
                case "Food":
                    sResult[0] = StaticURLHelper.FoodShow;
                    break;


                default: break;

            }
            return sResult;
        }
    }
}
