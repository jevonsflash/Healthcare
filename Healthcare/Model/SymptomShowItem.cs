using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Model
{
    class SymptomShowItem
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
        /// 部位
        /// </summary>
        public string place { get; set; }
        /// <summary>
        /// 疾病简介
        /// </summary>
        public string summary { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int rcount { get; set; }
        /// <summary>
        /// 收藏数
        /// </summary>
        public int fcount { get; set; }
        /// <summary>
        /// 相关疾病
        /// </summary>
        public string disease { get; set; }
        /// <summary>
        /// 病因
        /// </summary>
        public string causeText { get; set; }
        /// <summary>
        /// 相关检查
        /// </summary>
        public string check { get; set; }
        /// <summary>
        /// 相关药品
        /// </summary>
        public string drug { get; set; }

    }
}
