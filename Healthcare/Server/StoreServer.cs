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
   public class StoreServer
    {
        public IList<Model.StoreShowItem> StoreShowDeserializer(string jsonStr)
        {
            int total = 0;
            List<Model.StoreShowItem> storeShowItemModelList = new List<Model.StoreShowItem>();

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
                storeShowItemModelList.Add(JTokenToModel(item));
            }
            return storeShowItemModelList;
        }
        public Model.StoreShowItem StoreObjectDeserializer(string jsonStr)
        {
            JToken ja = (JToken)JsonConvert.DeserializeObject(jsonStr);
            return JTokenToModel(ja);

        }

        private StoreShowItem JTokenToModel(JToken item)
        {
            Model.StoreShowItem oStoreShowItem = new Model.StoreShowItem();
            int id = int.Parse(item["id"].ToString());
            int count = int.Parse(item["count"].ToString());
            int rcount = int.Parse(item["rcount"].ToString());
            int fcount = int.Parse(item["fcount"].ToString());
            string name = item["name"].ToString() ?? "";
            string img = item["img"].ToString() ?? "";
            long area = long.Parse(item["area"].ToString());    //区域
            string address = item["address"].ToString() ?? "";    //     地址 
            float x = float.Parse(item["x"].ToString()); //       地图x 
            float y = float.Parse(item["y"].ToString());    //       地图y 
            string tel = item["tel"].ToString() ?? "";     //      电话 
            string zipcode = item["zipcode"].ToString() ?? "";      //       邮编 
            string url = item["url"].ToString() ?? ""; //       网站URL 
            string number = item["number"].ToString() ?? "";     //      电话 
            string legal = item["legal"].ToString() ?? "";     
            string charge = item["charge"].ToString() ?? "";       
            string leader = item["leader"].ToString() ?? "";   
            string type = item["type"].ToString() ?? "";      
            string business = item["business"].ToString() ?? "";   
            string waddress = item["waddress"].ToString() ?? "";     
            long supervise = long.Parse(item["supervise"].ToString());
            string createdate = item["createdate"].ToString() ?? "";

            oStoreShowItem.id = id;
            oStoreShowItem.count = count;
            oStoreShowItem.rcount = rcount;
            oStoreShowItem.fcount = fcount;
            oStoreShowItem.name = name;//疾病名称
            oStoreShowItem.img = img;//图片
            oStoreShowItem.area = area;
            oStoreShowItem.address = address;
            oStoreShowItem.x = x;
            oStoreShowItem.y = y;
            oStoreShowItem.tel = tel;
            oStoreShowItem.number = number;
            oStoreShowItem.zipcode = zipcode;
            oStoreShowItem.url = url;
            oStoreShowItem.legal = legal;
            oStoreShowItem.charge = charge;
            oStoreShowItem.leader = leader;
            oStoreShowItem.type = type;
            oStoreShowItem.business = business;
            oStoreShowItem.waddress = waddress;
            oStoreShowItem.business = business;
            oStoreShowItem.supervise = supervise;
            oStoreShowItem.createdate = createdate;

            return oStoreShowItem;
        }

    }
}
