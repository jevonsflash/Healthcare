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
    public class FilterServer
    {
        public IList<Model.BaseMap> FilterDeserializer(string jsonStr, string filterNodeName)
        {
            List<Model.BaseMap> bodySieveModelList = new List<Model.BaseMap>();

            JArray ja = (JArray)JsonConvert.DeserializeObject(jsonStr);
            foreach (var item in ja)
            {
                Model.BaseMap oSieve = new Model.BaseMap();
                BaseMap oItem = JTokenToModel(item, ref oSieve);

                List<BaseMap> baseMap = FilterSubDeserializer(item[filterNodeName].ToString() ?? "");
                oSieve.BaseMaps = baseMap;
                bodySieveModelList.Add(oSieve);
            }
            return bodySieveModelList;

        }
        public List<BaseMap> FilterSubDeserializer(string jsonStr)
        {
            List<BaseMap> SubBaseMap = new List<BaseMap>();

            JArray ja = (JArray)JsonConvert.DeserializeObject(jsonStr);
            foreach (var item in ja)
            {
                Model.BaseMap oSieve = new Model.BaseMap();
                BaseMap oItem = JTokenToModel(item, ref oSieve);
                SubBaseMap.Add(oItem);
            }
            return SubBaseMap;

        }
        private BaseMap JTokenToModel(JToken item, ref BaseMap oSieve)
        {
            int id = int.Parse(item["id"].ToString());
            int ext = int.Parse(item["place"].ToString());
            int seq = int.Parse(item["seq"].ToString());
            string name = item["name"].ToString() ?? "";
            string keywords = item["keywords"].ToString() ?? "";
            string title = item["title"].ToString() ?? "";
            oSieve.id = id;
            oSieve.keywords = keywords;
            oSieve.name = name;
            oSieve.ext = ext;
            oSieve.seq = seq;
            oSieve.title = title;
            return oSieve;

        }
    }
}
