using Healthcare.Model;
using Healthcare.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Factory
{
    public class ItemDetailFactory
    {
        private static SymptomServer symptomser = new SymptomServer();
        public static Dictionary<string, string> GetContent(string typeName, string jsonStr)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            switch (typeName)
            {
                case "symptom":
                    SymptomShowItem temp = symptomser.SymptomObjectDeserializer(jsonStr);
                    result.Add("名称", temp.name);
                    result.Add("描述", temp.description);
                    result.Add("简介", temp.message);
                    result.Add("相关疾病", temp.disease);
                    result.Add("病因", temp.causetext);
                    result.Add("用药", temp.drug);
                    result.Add("诊断详情", temp.detailtext);
                    result.Add("检测项目", temp.checks);
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
