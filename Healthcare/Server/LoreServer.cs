using Healthcare.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Server
{
    public class LoreServer
    {
        public IList<Model.LoreShowItem> LoreShowDeserializer(string jsonStr)
        {
            int total = 0;
            List<Model.LoreShowItem> loreShowItemModelList = new List<Model.LoreShowItem>();

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
                loreShowItemModelList.Add(JTokenToModel(item));
            }
            return loreShowItemModelList;
        }
        public Model.LoreShowItem LoreObjectDeserializer(string jsonStr)
        {
            JToken ja = (JToken)JsonConvert.DeserializeObject(jsonStr);
            return JTokenToModel(ja);

        }

        private LoreShowItem JTokenToModel(JToken item)
        {
            Model.LoreShowItem oLoreShowItem = new Model.LoreShowItem();



            int id = int.Parse(item["id"].ToString());
            int count = int.Parse(item["count"].ToString());
            int rcount = int.Parse(item["rcount"].ToString());
            int fcount = int.Parse(item["fcount"].ToString());
            string img = item["img"].ToString() ?? "";
            string description = item["description"].ToString() ?? "";
            string keywords = item["keywords"].ToString() ?? "";
            int loreclass = int.Parse(item["loreclass"].ToString());
            long time = long.Parse(item["time"].ToString());
            string title = item["title"].ToString() ?? "";

            oLoreShowItem.id = id;
            oLoreShowItem.count = count;
            oLoreShowItem.rcount = rcount;
            oLoreShowItem.fcount = fcount;
            oLoreShowItem.img = img;//图片
            oLoreShowItem.description = description;
            oLoreShowItem.keywords = keywords;
            oLoreShowItem.loreclass = loreclass;
            oLoreShowItem.time = time;
            oLoreShowItem.title = title;


            return oLoreShowItem;
        }

    }
}
