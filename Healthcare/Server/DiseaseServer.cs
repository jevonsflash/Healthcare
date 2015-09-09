using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Server
{
    public class DiseaseServer
    {
        public IList<Model.DiseaseShowItem> DiseaseShowDeserializer(string jsonStr)
        {
            int total = 0;
            List<Model.DiseaseShowItem> diseaseShowItemModelList = new List<Model.DiseaseShowItem>();

            Dictionary<string, string> result = new Dictionary<string, string>();
            JObject jobject = JObject.Parse(jsonStr);
            if (jobject.Property("total") != null)
            {
                total = int.Parse(jobject["total"].ToString());
            }
            string jsonArrayText1 = jobject["tngou"].ToString();
            JArray ja = (JArray)JsonConvert.DeserializeObject(jsonArrayText1);
            foreach (var item in ja)
            {
                Model.DiseaseShowItem oDiseaseShowItem = new Model.DiseaseShowItem();
                int id = int.Parse(item["id"].ToString());
                int count = int.Parse(item["count"].ToString());
                int rcount = int.Parse(item["rcount"].ToString());
                int fcount = int.Parse(item["fcount"].ToString());
                string name = item["name"].ToString() ?? "";
                string img = item["img"].ToString() ?? "";
                string department = item["department"].ToString() ?? "";
                string place = item["place"].ToString() ?? "";
                string message = item["message"].ToString() ?? "";
                string keywords = item["keywords"].ToString() ?? "";
                string description = item["description"].ToString() ?? "";
                string symptomtext = item["symptomtext"].ToString() ?? "";
                string symptom = item["symptom"].ToString() ?? "";
                string drug = item["drug"].ToString() ?? "";
                string drugtext = item["drugtext"].ToString() ?? "";
                string food = item["food"].ToString() ?? "";
                string foodtext = item["foodtext"].ToString() ?? "";
                string causetext = item["causetext"].ToString() ?? "";
                string checks = item["checks"].ToString() ?? "";
                string checktext = item["checktext"].ToString() ?? "";
                string disease = item["disease"].ToString() ?? "";
                string diseasetext = item["diseasetext"].ToString() ?? "";
                string caretext = item["caretext"].ToString() ?? "";
                oDiseaseShowItem.id = id;
                oDiseaseShowItem.count = count;
                oDiseaseShowItem.rcount = rcount;
                oDiseaseShowItem.fcount = fcount;
                oDiseaseShowItem.name = name;//疾病名称
                oDiseaseShowItem.img = img;//图片
                oDiseaseShowItem.department = department;//疾病科
                oDiseaseShowItem.place = place;//疾病部位
                oDiseaseShowItem.message = message;//简介，摘要
                oDiseaseShowItem.keywords = keywords;
                oDiseaseShowItem.description = description;
                oDiseaseShowItem.symptomtext = symptomtext;//病状
                oDiseaseShowItem.symptom = symptom;//相关症状
                oDiseaseShowItem.drug = drug;//相关药品
                oDiseaseShowItem.drugtext = drugtext;//用药说明
                oDiseaseShowItem.food = food;//相关食品
                oDiseaseShowItem.foodtext = foodtext;//健康保健
                oDiseaseShowItem.causetext = causetext;//病因
                oDiseaseShowItem.checks = checks;//检测项目
                oDiseaseShowItem.checktext = checktext;//检测说
                oDiseaseShowItem.disease = disease;//并发疾病
                oDiseaseShowItem.diseasetext = diseasetext;//并发                                 
                oDiseaseShowItem.caretext = caretext;//预防护理
                diseaseShowItemModelList.Add(oDiseaseShowItem);

            }
            return diseaseShowItemModelList;

        }

    }
}
