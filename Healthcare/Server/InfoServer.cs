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
    public class InfoServer
    {
        public IList<Model.InfoShowItem> InfoShowDeserializer(string jsonStr)
        {
            int total = 0;
            List<Model.InfoShowItem> infoShowItemModelList = new List<Model.InfoShowItem>();

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
                infoShowItemModelList.Add(JTokenToModel(item));
            }
            return infoShowItemModelList;
        }
        public Model.InfoShowItem InfoObjectDeserializer(string jsonStr)
        {
            JToken ja = (JToken)JsonConvert.DeserializeObject(jsonStr);
            return JTokenToModel(ja);

        }

        private InfoShowItem JTokenToModel(JToken item)
        {
            Model.InfoShowItem oInfoShowItem = new Model.InfoShowItem();



            int id = int.Parse(item["id"].ToString());
            int count = int.Parse(item["count"].ToString());
            int rcount = int.Parse(item["rcount"].ToString());
            int fcount = int.Parse(item["fcount"].ToString());
            string img = item["img"].ToString() ?? "";
            string description = item["description"].ToString() ?? "";
            string keywords = item["keywords"].ToString() ?? "";
            int infoclass = int.Parse(item["infoclass"].ToString());
            long time = long.Parse(item["time"].ToString());
            string title = item["title"].ToString() ?? "";

            oInfoShowItem.id = id;
            oInfoShowItem.count = count;
            oInfoShowItem.rcount = rcount;
            oInfoShowItem.fcount = fcount;
            oInfoShowItem.img = img;//图片
            oInfoShowItem.description = description;
            oInfoShowItem.keywords = keywords;
            oInfoShowItem.infoclass = infoclass;
            oInfoShowItem.time = time;
            oInfoShowItem.title = title;


            return oInfoShowItem;
        }

    }
}
