using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Model
{
    public class OperationShowItem
    {
        public int id { get; set; }
        public string name { get; set; }//  手术名称    
        public string img { get; set; }//图片logo
        public string description { get; set; }//简介，摘要
        public string keywords { get; set; }//
        public string department { get; set; }//手术科室
        public string place { get; set; }//手术部位
        public string disease { get; set; }//相关疾病
        public string message { get; set; }//详情
        public int count { get; set; }
        public int rcount { get; set; }//回复
        public int fcount { get; set; }//收藏
    }
}
