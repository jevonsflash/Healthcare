using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Server
{
    class DiseaseServer
    {
        private bool GetJsonResultStatus(string jsonStr, out int total)
        {
            total = 0;
            JObject jobject = JObject.Parse(jsonStr);
            if (jobject.Property("success") != null && jobject.Property("yi18") != null)
            {
                if (jobject["success"].ToString().Equals("true", StringComparison.OrdinalIgnoreCase))
                {

                    if (jobject.Property("total") != null)
                    {
                        total = int.Parse(jobject["total"].ToString());
                    }
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public IList<Model.GeneralSearchItem> DiseaseSearchDeserializer(string jsonStr)
        {
            int total = 0;
            List<Model.GeneralSearchItem> diseaseSearchItemModelList = new List<Model.GeneralSearchItem>();
            Dictionary<string, string> result = new Dictionary<string, string>();
            JObject jobject = JObject.Parse(jsonStr);
            if (GetJsonResultStatus(jsonStr, out total))
            {
                string jsonArrayText1 = jobject["yi18"].ToString();
                JArray ja = (JArray)JsonConvert.DeserializeObject(jsonArrayText1);
                foreach (var item in ja)
                {
                    Model.GeneralSearchItem diseaseSearchItemModel = new Model.GeneralSearchItem();

                    int id = int.Parse(item["id"].ToString() ?? "");
                    string title = item["title"].ToString() ?? "";
                    string img = item["img"].ToString() ?? "";
                    diseaseSearchItemModel.id = id;
                    diseaseSearchItemModel.img = img;
                    diseaseSearchItemModel.title = title;
                    diseaseSearchItemModelList.Add(diseaseSearchItemModel);
                }
            }
            return diseaseSearchItemModelList;
        }
        public Model.DiseaseShowItem DiseaseShowDeserializer(string jsonStr)
        {
            int total = 0;
            Model.DiseaseShowItem diseaseShowItemModel = new Model.DiseaseShowItem();

            Dictionary<string, string> result = new Dictionary<string, string>();
            JObject jobject = JObject.Parse(jsonStr);
            if (GetJsonResultStatus(jsonStr, out total))
            {
                string jsonArrayText1 = jobject["yi18"].ToString();
                JObject item = (JObject)JsonConvert.DeserializeObject(jsonArrayText1);
                int id = int.Parse(item["id"].ToString() ?? "-1");
                //必要字段
                string name = item["name"].ToString() ?? "";
                string img = item["img"].ToString() ?? "";
                int count = int.Parse(item["count"].ToString() ?? "0");
                string department = item["department"].ToString() ?? "";
                string place = item["place"].ToString() ?? "";
                //非必要字段
                string summary = item["summary"].ToString() ?? "";
                string symptom = item["symptom"].ToString() ?? "";
                string symptomText = item["symptomText"].ToString() ?? "";
                string foodText = item["foodText"].ToString() ?? "";
                string disease = item["disease"].ToString() ?? "";
                string diseaseText = item["diseaseText"].ToString() ?? "";
                string causeText = item["causeText"].ToString() ?? "";
                string careText = item["careText"].ToString() ?? "";
                diseaseShowItemModel.id = id;
                diseaseShowItemModel.img = img;
                diseaseShowItemModel.name = name;
                diseaseShowItemModel.count = count;
                diseaseShowItemModel.department = department;
                diseaseShowItemModel.place = place;
                diseaseShowItemModel.summary = summary;
                diseaseShowItemModel.symptom = symptom;
                diseaseShowItemModel.symptomText = symptomText;
                diseaseShowItemModel.foodText = foodText;
                diseaseShowItemModel.disease = disease;
                diseaseShowItemModel.diseaseText = diseaseText;
                diseaseShowItemModel.causeText = causeText;
                diseaseShowItemModel.careText = causeText;

            }
            return diseaseShowItemModel;

        }

    }
}
