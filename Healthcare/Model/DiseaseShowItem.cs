using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Model
{
    public class DiseaseShowItem
    {
        public int id { get; set; }//id
        public String name { get; set; }//疾病名称
        public String img { get; set; }//图片
        public String department { get; set; }//疾病科室
        public String place { get; set; }//疾病部位
        public String message { get; set; }//简介，摘要
        public String keywords { get; set; }
        public String description { get; set; }
        public String symptomtext { get; set; }//病状描述
        public String symptom { get; set; }//相关症状
        public String drug { get; set; }//相关药品
        public String drugtext { get; set; }//用药说明
        public String food { get; set; }//相关食品
        public String foodtext { get; set; }//健康保健
        public String causetext { get; set; }//病因
        public String checks { get; set; }//检测项目
        public String checktext { get; set; }//检测说明
        public String disease { get; set; }//并发疾病
        public String diseasetext { get; set; }//并发症状说明
        public String caretext { get; set; }//预防护理
        public int count { get; set; }
        public int rcount { get; set; }//回复
        public int fcount { get; set; }//收藏
    }
}
