using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Model
{
    public class CheckShowItem
    {
        public int id { get; set; }
        public string name { set; get; }//检查项目名称
        public string img { set; get; }
        public string keywords { set; get; }
        public string description { set; get; }// 简介，描述
        public string department { set; get; }//手术科室
        public string place { set; get; }//手术部位
        public string disease { set; get; }//相关疾病
        public string symptom { set; get; }//相关病状
        public string message { set; get; }//详情信息
        public int checkclass { set; get; }//菜单
        public int count { set; get; }//阅读
        public int rcount { set; get; }//回复
        public int fcount { set; get; }//收藏

    }
}
