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
    public class FoodServer
    {
        public IList<Model.FoodShowItem> FoodShowDeserializer(string jsonStr)
        {
            int total = 0;
            List<Model.FoodShowItem> foodShowItemModelList = new List<Model.FoodShowItem>();

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
                foodShowItemModelList.Add(JTokenToModel(item));
            }
            return foodShowItemModelList;
        }
        public Model.FoodShowItem FoodObjectDeserializer(string jsonStr)
        {
            JToken ja = (JToken)JsonConvert.DeserializeObject(jsonStr);
            return JTokenToModel(ja);

        }

        private FoodShowItem JTokenToModel(JToken item)
        {
            Model.FoodShowItem oFoodShowItem = new Model.FoodShowItem();
            int count = int.Parse(item["count"].ToString());
            int rcount = int.Parse(item["rcount"].ToString());
            int fcount = int.Parse(item["fcount"].ToString());
            string name = item["name"].ToString() ?? "";
            string img = item["img"].ToString() ?? "";
            string food = item["food"].ToString() ?? "";
            string images = item["images"].ToString() ?? "";
            string description = item["description"].ToString() ?? "";
            string keywords = item["keywords"].ToString() ?? "";
            string message = item["message"].ToString() ?? "";

            oFoodShowItem.count = count;
            oFoodShowItem.rcount = rcount;
            oFoodShowItem.fcount = fcount;
            oFoodShowItem.name = name;//名称
            oFoodShowItem.img = img;//图片
            oFoodShowItem.food = food;//食物
            oFoodShowItem.images = images;//图片, 
            oFoodShowItem.description = description;//描述
            oFoodShowItem.keywords = keywords;//关键字
            oFoodShowItem.message = message;//资讯内容

            return oFoodShowItem;
        }

    }
}
