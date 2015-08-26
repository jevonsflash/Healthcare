using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Server
{
    class SymptomServer
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
                        total = int.Parse(jobject.Property("total").ToString());
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

        public IList<Model.GeneralSearchItem> SymptomSearchDeserializer(string jsonStr)
        {
            int total = 0;
            List<Model.GeneralSearchItem> generalSearchItemModelList = new List<Model.GeneralSearchItem>();
            Dictionary<string, string> result = new Dictionary<string, string>();
            JObject jobject = JObject.Parse(jsonStr);
            if (GetJsonResultStatus(jsonStr, out total))
            {
                string jsonArrayText1 = jobject["yi18"].ToString();
                JArray ja = (JArray)JsonConvert.DeserializeObject(jsonArrayText1);
                foreach (var item in ja)
                {
                    Model.GeneralSearchItem generalSearchItemModel = new Model.GeneralSearchItem();

                    int id = int.Parse(item["id"].ToString() ?? "");
                    string title = item["title"].ToString() ?? "";
                    string img = item["img"].ToString() ?? "";
                    generalSearchItemModel.id = id;
                    generalSearchItemModel.img = img;
                    generalSearchItemModel.title = title;
                    generalSearchItemModelList.Add(generalSearchItemModel);
                }
            }
            return generalSearchItemModelList;
        }
        public Model.SymptomShowItem SymptomShowDeserializer(string jsonStr)
        {
            int total = 0; 
            Model.SymptomShowItem symptomShowItemModel = new Model.SymptomShowItem();
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
                string place = item["place"].ToString() ?? "";
                //非必要字段
                string summary = item["summary"].ToString() ?? "";
                int rcount = int.Parse(item["rcount"].ToString() ?? "0");
                int fcount = int.Parse(item["fcount"].ToString() ?? "0");
                string disease = item["disease"].ToString() ?? "";
                string causeText = item["causeText"].ToString() ?? "";
                string check = item["check"].ToString() ?? "";
                string drug = item["drug"].ToString() ?? "";
                symptomShowItemModel.id = id;
                symptomShowItemModel.img = img;
                symptomShowItemModel.name = name;
                symptomShowItemModel.count = count;
                symptomShowItemModel.place = place;
                symptomShowItemModel.summary = summary;
                symptomShowItemModel.rcount = rcount;
                symptomShowItemModel.fcount = fcount;
                symptomShowItemModel.disease = disease;
                symptomShowItemModel.causeText = causeText;
                symptomShowItemModel.check = check;
                symptomShowItemModel.drug = drug;
            }
            return symptomShowItemModel;

        }

    }
}
