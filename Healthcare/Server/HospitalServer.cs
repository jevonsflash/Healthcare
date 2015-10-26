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
    public class HospitalServer
    {
        public IList<Model.HospitalShowItem> HospitalShowDeserializer(string jsonStr)
        {
            int total = 0;
            List<Model.HospitalShowItem> hospitalShowItemModelList = new List<Model.HospitalShowItem>();

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
                hospitalShowItemModelList.Add(JTokenToModel(item));
            }
            return hospitalShowItemModelList;
        }
        public Model.HospitalShowItem HospitalObjectDeserializer(string jsonStr)
        {
            JToken ja = (JToken)JsonConvert.DeserializeObject(jsonStr);
            return JTokenToModel(ja);

        }

        private HospitalShowItem JTokenToModel(JToken item)
        {
            Model.HospitalShowItem oHospitalShowItem = new Model.HospitalShowItem();

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
            string fax = item["fax"].ToString() ?? ""; //       传真 
            string zipcode = item["zipcode"].ToString() ?? "";      //       邮编 
            string url = item["url"].ToString() ?? ""; //       网站URL 
            string mail = item["mail"].ToString() ?? "";     //      医院邮箱 
            string gobus = item["gobus"].ToString() ?? "";     //     坐车方式 
            string level = item["level"].ToString() ?? "";    //      医院等级 
            string nature = item["nature"].ToString() ?? "";    //       经营性质 
            string mtype = item["mtype"].ToString() ?? "";    //      医保类型 

            oHospitalShowItem.id = id;
            oHospitalShowItem.count = count;
            oHospitalShowItem.rcount = rcount;
            oHospitalShowItem.fcount = fcount;
            oHospitalShowItem.name = name;//疾病名称
            oHospitalShowItem.img = img;//图片
            oHospitalShowItem.area = area;
            oHospitalShowItem.address = address;
            oHospitalShowItem.x = x;
            oHospitalShowItem.y = y;
            oHospitalShowItem.tel = tel;
            oHospitalShowItem.fax = fax;
            oHospitalShowItem.zipcode = zipcode;
            oHospitalShowItem.url = url;
            oHospitalShowItem.mail = mail;
            oHospitalShowItem.gobus = gobus;
            oHospitalShowItem.level = level;
            oHospitalShowItem.nature = nature;
            oHospitalShowItem.mtype = mtype;


            return oHospitalShowItem;
        }


    }
}
