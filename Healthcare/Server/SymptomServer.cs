using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Server
{
    public class SymptomServer
    {

        public List<Model.SymptomShowItem> SymptomListDeserializer(string jsonStr)
        {
            int total = 0;
            List<Model.SymptomShowItem> symptomShowItemModelList = new List<Model.SymptomShowItem>();

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
                symptomShowItemModelList.Add(JTokenToModel(item));
            }
            return symptomShowItemModelList;

        }

        public Model.SymptomShowItem SymptomObjectDeserializer(string jsonStr)
        {
            JToken ja = (JToken)JsonConvert.DeserializeObject(jsonStr);
            return JTokenToModel(ja);

        }
        private Model.SymptomShowItem JTokenToModel(JToken item)
        {
            Model.SymptomShowItem oSymptomShowItem = new Model.SymptomShowItem();

            int id = int.Parse(item["id"].ToString() ?? "-1");
            int count = int.Parse(item["count"].ToString() ?? "0");
            int rcount = int.Parse(item["rcount"].ToString() ?? "0");
            int fcount = int.Parse(item["fcount"].ToString() ?? "0");
            string name = item["name"].ToString() ?? "";
            string img = item["img"].ToString() ?? "";
            string keywords = item["keywords"].ToString() ?? "";
            string description = item["description"].ToString() ?? "";
            string department = item["department"].ToString() ?? "";
            string place = item["place"].ToString() ?? "";
            string message = item["message"].ToString() ?? "";
            string disease = item["disease"].ToString() ?? "";
            string causetext = item["causetext"].ToString() ?? "";
            string checks = item["checks"].ToString() ?? "";
            string drug = item["drug"].ToString() ?? "";
            string detailtext = item["detailtext"].ToString() ?? "";

            oSymptomShowItem.id = id;
            oSymptomShowItem.count = count;
            oSymptomShowItem.rcount = rcount;
            oSymptomShowItem.fcount = fcount;
            oSymptomShowItem.keywords = keywords;
            oSymptomShowItem.name = name;
            oSymptomShowItem.img = img;
            oSymptomShowItem.keywords = keywords; ;
            oSymptomShowItem.description = description; ;
            oSymptomShowItem.department = department;
            oSymptomShowItem.place = place;
            oSymptomShowItem.message = message;
            oSymptomShowItem.disease = disease;
            oSymptomShowItem.causetext = causetext;
            oSymptomShowItem.drug = drug;
            oSymptomShowItem.detailtext = detailtext;
            oSymptomShowItem.checks = checks;

            return oSymptomShowItem;
        }

    }
}
