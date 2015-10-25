using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Helper
{
    public class TimeHelper
    {
        /// <summary>  
        /// Unix时间戳格式转换为DateTime时间格式  
        /// </summary>  
        /// <param name="timeStamp">Unix时间戳格式</param>  
        /// <returns>C#格式时间</returns>  
        public static DateTime TimeStamptoDateTime(string timeStamp)
        {
            timeStamp = timeStamp.Substring(0, 10);
            DateTime dtStart = new DateTime(1970, 1, 1);
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }


        /// <summary>  
        /// DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time"> DateTime时间格式</param>  
        /// <returns>Unix时间戳格式</returns>  
        public static int DateTimetoTimeStamp(System.DateTime time)
        {
            System.DateTime startTime = new System.DateTime(1970, 1, 1);
            return (int)(time - startTime).TotalSeconds;
        }
    }
}
