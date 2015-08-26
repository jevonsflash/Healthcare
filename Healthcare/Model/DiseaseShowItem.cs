using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Model
{
    class DiseaseShowItem
    {
        /// <summary>
        /// 疾病ID 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 疾病标题 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string img { get; set; }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int count { get; set; } 
        /// <summary>
        /// 科室
        /// </summary>
        public string department { get; set; }
        /// <summary>
        /// 部位
        /// </summary>
        public string place { get; set; }
        /// <summary>
        /// 疾病简介
        /// </summary>
        public string summary { get; set; }
        /// <summary>
        /// 相关病状
        /// </summary>
        public string symptom { get; set; }
        /// <summary>
        /// 病状详情
        /// </summary>
        public string symptomText { get; set; }
        /// <summary>
        /// 食疗
        /// </summary>
        public string foodText { get; set; }
        /// <summary>
        /// 相关疾病
        /// </summary>
        public string disease { get; set; }
        /// <summary>
        /// 疾病说明
        /// </summary>
        public string diseaseText { get; set; }
        /// <summary>
        /// 病因
        /// </summary>
        public string causeText { get; set; }
        /// <summary>
        /// 注意、医疗 
        /// </summary>
        public string careText { get; set; }
        
    }
}
