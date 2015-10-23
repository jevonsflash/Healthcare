using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Model
{
    public class StoreShowItem
    {

        public int id { get; set; }
        public string name { get; set; }//      药店名称 
        public string img { get; set; }//       图片 
        public string address { get; set; }//       地址 
        public long area { get; set; }//       地域 
        public float x { get; set; }//       地图X 
        public float y { get; set; }//       地图y 
        public string tel { get; set; }//       电话 
        public string zipcode { get; set; }//       邮编 
        public string url { get; set; }//       官方网站 
        public string number { get; set; }//       证号 
        public string legal { get; set; }//       法定代表人 
        public string charge { get; set; }//       企业负责人  
        public string leader { get; set; }//       质量负责人 
        public string type { get; set; }//       经营方式 
        public string business { get; set; }//      经营范围     
        public string waddress { get; set; }//       仓库地址 
        public long supervise { get; set; }
        public string createdate { get; set; }//       创建时间 
        public int count { get; set; }//     
        public int rcount { get; set; }
        public int fcount { get; set; }
    }
}
