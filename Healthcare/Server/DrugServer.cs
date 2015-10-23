using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Model;

namespace Healthcare.Server
{
    public class DrugServer
    {
        public IList<Model.DrugShowItem> DrugShowDeserializer(string jsonStr)
        {
            int total = 0;
            List<Model.DrugShowItem> DrugShowItemModelList = new List<Model.DrugShowItem>();

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
                DrugShowItemModelList.Add(JTokenToModel(item));
            }
            return DrugShowItemModelList;
        }
        public Model.DrugShowItem DrugObjectDeserializer(string jsonStr)
        {
            JToken ja = (JToken)JsonConvert.DeserializeObject(jsonStr);
            return JTokenToModel(ja);

        }

        private DrugShowItem JTokenToModel(JToken item)
        {
            Model.DrugShowItem oDrugShowItem = new Model.DrugShowItem();
            int id = int.Parse(item["id"].ToString());
            int count = int.Parse(item["count"].ToString());
            int rcount = int.Parse(item["rcount"].ToString());
            int fcount = int.Parse(item["fcount"].ToString());
            string name = item["name"].ToString() ?? "";
            string img = item["img"].ToString() ?? "";
            string message = item["message"].ToString() ?? "";
            int price = int.Parse(item["price"].ToString());
            string tag = item["tag"].ToString() ?? "";
            string keywords = item["keywords"].ToString() ?? "";
            string type = item["type"].ToString() ?? "";


            oDrugShowItem.id = id;
            oDrugShowItem.count = count;
            oDrugShowItem.rcount = rcount;
            oDrugShowItem.fcount = fcount;
            oDrugShowItem.name = name;//疾病名称
            oDrugShowItem.img = img;
            oDrugShowItem.message = message;
            oDrugShowItem.price = price;
            oDrugShowItem.tag = tag;
            oDrugShowItem.keywords = keywords;
            oDrugShowItem.type = type;


            return oDrugShowItem;
        }
    }
}
