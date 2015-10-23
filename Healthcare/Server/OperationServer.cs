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
    public class OperationServer
    {
        public IList<Model.OperationShowItem> OperationShowDeserializer(string jsonStr)
        {
            int total = 0;
            List<Model.OperationShowItem> operationShowItemModelList = new List<Model.OperationShowItem>();

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
                operationShowItemModelList.Add(JTokenToModel(item));
            }
            return operationShowItemModelList;
        }
        public Model.OperationShowItem OperationObjectDeserializer(string jsonStr)
        {
            JToken ja = (JToken)JsonConvert.DeserializeObject(jsonStr);
            return JTokenToModel(ja);

        }

        private OperationShowItem JTokenToModel(JToken item)
        {
            Model.OperationShowItem oOperationShowItem = new Model.OperationShowItem();
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

            oOperationShowItem.id = id;
            oOperationShowItem.rcount = rcount;
            oOperationShowItem.fcount = fcount;
            oOperationShowItem.name = name;//疾病名称
            oOperationShowItem.img = img;//图片
            oOperationShowItem.department = department;//疾病科
            oOperationShowItem.place = place;//疾病部位
            oOperationShowItem.message = message;//简介，摘要
            oOperationShowItem.keywords = keywords;
            oOperationShowItem.description = description;
            
            return oOperationShowItem;
        }
    }

}

