using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Model
{
    public class SymptomShowItem
    {
        public int id { get; set; }
        public String name { get; set; }//疾病名称
        public String img { get; set; }//图片
        public String keywords { get; set; }
        public String description { get; set; }
        public String department { get; set; }//疾病科室
        public String place { get; set; }//疾病部位
        public String message { get; set; }//简介，摘要
        public String disease { get; set; }//相关疾病
        public String causetext { get; set; }//病因
        public String drug { get; set; }//相关药品
        public String detailtext { get; set; }//诊断详情
        public String checks { get; set; }//检测项目
        public int count { get; set; }//访问次数
        public int rcount { get; set; }//回复
        public int fcount { get; set; }//收藏
    }
}
