using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Server
{
    public class CheckServer
    {
        public List<Model.CheckShowItem> CheckListDeserializer(string jsonStr)
        {
            int total = 0;
            List<Model.CheckShowItem> checkShowItemModelList = new List<Model.CheckShowItem>();

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
                checkShowItemModelList.Add(JTokenToModel(item));
            }
            return checkShowItemModelList;

        }

        public Model.CheckShowItem CheckObjectDeserializer(string jsonStr)
        {
            JToken ja = (JToken)JsonConvert.DeserializeObject(jsonStr);
            return JTokenToModel(ja);

        }
        private Model.CheckShowItem JTokenToModel(JToken item)
        {
            Model.CheckShowItem oCheckShowItem = new Model.CheckShowItem();

            int id = int.Parse(item["id"].ToString() ?? "0");
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
            string symptom = item["symptom"].ToString() ?? "";
            int checkclass = int.Parse(item["checkclass"].ToString() ?? "0");

            oCheckShowItem.id = id;
            oCheckShowItem.count = count;
            oCheckShowItem.rcount = rcount;
            oCheckShowItem.fcount = fcount;
            oCheckShowItem.keywords = keywords;
            oCheckShowItem.name = name;
            oCheckShowItem.img = img;
            oCheckShowItem.description = description;
            oCheckShowItem.department = department;
            oCheckShowItem.place = place;
            oCheckShowItem.message = message;
            oCheckShowItem.disease = disease;
            oCheckShowItem.symptom = symptom;
            oCheckShowItem.place = place;
            oCheckShowItem.checkclass = checkclass;
            return oCheckShowItem;
        }

    }
}
