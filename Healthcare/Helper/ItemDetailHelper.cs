using Healthcare.Model;
using Healthcare.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Helper
{
    public class ItemDetailHelper
    {
        private static SymptomServer symptomser = new SymptomServer();
        private static DiseaseServer diseaseser = new DiseaseServer();
        private static DrugServer drugser = new DrugServer();
        private static CheckServer checkser = new CheckServer();
        private static OperationServer operationser = new OperationServer();
        private static FoodServer foodser = new FoodServer();

        public static Dictionary<string, string> GetContent(string typeName, string jsonStr)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            switch (typeName)
            {
                case "Symptom":
                    SymptomShowItem oSymptom = symptomser.SymptomObjectDeserializer(jsonStr);
                    result.Add("名称", oSymptom.name);
                    result.Add("描述", oSymptom.description);
                    result.Add("简介", oSymptom.message);
                    result.Add("相关疾病", oSymptom.disease);
                    result.Add("病因", oSymptom.causetext);
                    result.Add("用药", oSymptom.drug);
                    result.Add("诊断详情", oSymptom.detailtext);
                    result.Add("检测项目", oSymptom.checks);
                    break;
                case "Disease":
                    DiseaseShowItem oDisease = diseaseser.DiseaseObjectDeserializer(jsonStr);
                    result.Add("名称", oDisease.name);
                    result.Add("描述", oDisease.description);
                    result.Add("简介", oDisease.message);
                    result.Add("相关疾病", oDisease.disease);
                    result.Add("病因", oDisease.causetext);
                    result.Add("用药", oDisease.drug);
                    result.Add("检测项目", oDisease.checks);
                    result.Add("检测说明", oDisease.checktext);//检测说明
                    result.Add("并发疾病", oDisease.disease);//并发疾病
                    result.Add("并发症状说明", oDisease.diseasetext);//并发症状说明
                    result.Add("预防护理", oDisease.caretext);//预防护理
                    break;
                case "Drug":
                    DrugShowItem oDrug = drugser.DrugObjectDeserializer(jsonStr);
                    result.Add("名称", oDrug.name);
                    result.Add("描述", oDrug.description);
                    result.Add("详细信息", oDrug.message);
                    result.Add("价格", oDrug.price.ToString());
                    result.Add("种类", oDrug.type);
                    break;
                case "Check":
                    CheckShowItem oCheck = checkser.CheckObjectDeserializer(jsonStr);
                    result.Add("名称", oCheck.name);
                    result.Add("描述", oCheck.description);
                    result.Add("手术科室", oCheck.department);
                    result.Add("手术部位", oCheck.place);
                    result.Add("相关疾病", oCheck.disease);
                    result.Add("相关病状", oCheck.symptom);
                    result.Add("详细信息", oCheck.message);
                    break;
                case "Operation":
                    OperationShowItem oOperation = operationser.OperationObjectDeserializer(jsonStr);
                    result.Add("名称", oOperation.name);
                    result.Add("描述", oOperation.description);
                    result.Add("相关疾病", oOperation.disease);
                    result.Add("手术科室", oOperation.department);   //手术科室
                    result.Add("手术部位", oOperation.place);   //手术部位
                    result.Add("详细信息", oOperation.message); //详情
                    break;
                case "Food":
                    FoodShowItem oFood = foodser.FoodObjectDeserializer(jsonStr);
                    result.Add("名称", oFood.name);
                    result.Add("描述", oFood.description);
                    result.Add("食物", oFood.food);
                    break;

                default:
                    break;
            }
            return result;
        }
    }
}
