using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Model
{
    public class HospitalShowItem
    {
        public int id { get; set; }
        public string name { get; set; }   //      医院名称 
        public string img { get; set; }   //      医院展示效果图  医院LOGO 
        public long area { get; set; }     //区域
        public string address { get; set; }   //     地址 
        public float x { get; set; }   //       地图x 
        public float y { get; set; }   //       地图y 
        public string tel { get; set; }   //      电话 
        public string fax { get; set; }   //       传真 
        public string zipcode { get; set; }   //       邮编 
        public string url { get; set; }   //       网站URL 
        public string mail { get; set; }   //      医院邮箱 
        public string gobus { get; set; }   //     坐车方式 
        public string level { get; set; }   //      医院等级 
        public string nature { get; set; }   //       经营性质 
        public string mtype { get; set; }   //      医保类型 
        public int count { get; set; }   //     访问量 
        public int rcount { get; set; }
        public int fcount { get; set; }
    }
}
