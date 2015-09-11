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
    public class BodyServer
    {
        public IList<Model.BodyMap> bodyDeserializer(string jsonStr)
        {
            List<Model.BodyMap> bodySieveModelList = new List<Model.BodyMap>();

            JArray ja = (JArray)JsonConvert.DeserializeObject(jsonStr);
            foreach (var item in ja)
            {
                Model.BodyMap oBodySieve = new Model.BodyMap();
                int id = int.Parse(item["id"].ToString());
                int place = int.Parse(item["place"].ToString());
                int seq = int.Parse(item["seq"].ToString());
                string name = item["name"].ToString() ?? "";
                string keywords = item["keywords"].ToString() ?? "";
                List<Place> places = bodySubDeserializer(item["places"].ToString() ?? "");
                string title = item["title"].ToString() ?? "";

                oBodySieve.id = id;
                oBodySieve.keywords = keywords;
                oBodySieve.name = name;
                oBodySieve.place = place;
                oBodySieve.places = places;
                oBodySieve.seq = seq;
                oBodySieve.title = title;
                bodySieveModelList.Add(oBodySieve);
            }
            return bodySieveModelList;

        }
        public List<Place> bodySubDeserializer(string jsonStr)
        {
            List<Place> PlaceList = new List<Place>();

            JArray ja = (JArray)JsonConvert.DeserializeObject(jsonStr);
            foreach (var item in ja)
            {
                Place oPlace = new Place();
                int id = int.Parse(item["id"].ToString());
                int place = int.Parse(item["place"].ToString());
                int seq = int.Parse(item["seq"].ToString());
                string name = item["name"].ToString() ?? "";
                string keywords = item["keywords"].ToString() ?? "";
                string title = item["title"].ToString() ?? "";
                oPlace.id = id;
                oPlace.keywords = keywords;
                oPlace.name = name;
                oPlace.place = place;
                oPlace.seq = seq;
                oPlace.title = title;
                PlaceList.Add(oPlace);
            }
            return PlaceList;

        }
    }
}
