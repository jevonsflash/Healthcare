using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Model
{
    public class InfoShowItem
    {
        public int id { get; set; }
        public string title { get; set; }//资讯标题
        public int infoclass { get; set; }//分类
        public string img { get; set; }//图片
        public string description { get; set; }//描述
        public string keywords { get; set; }//关键字
        public string message { get; set; }//资讯内容
        public int count { get; set; }//访问次数
        public int fcount { get; set; }//收藏数
        public int rcount { get; set; }//评论读数
        public long time { get; set; }
    }
}
