using Healthcare.Model;
using Healthcare.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Helper
{
    public class DeserializeHelper
    {
        private static SymptomServer symptomser = new SymptomServer();
        private static DiseaseServer diseaseser = new DiseaseServer();
        public static List<KeyWordsMap> GetMap(string typeName, string jsonStr)
        {
            List<KeyWordsMap> symptomMap = new List<KeyWordsMap>();
            Dictionary<string, string> result = new Dictionary<string, string>();
            switch (typeName)
            {
                case "Symptom": List<SymptomShowItem> temp = symptomser.SymptomListDeserializer(jsonStr).ToList();
                    symptomMap = temp.Select(c => new KeyWordsMap
                    {
                        id = c.id,
                        name = c.name,
                        keywords = c.keywords.TrimEnd(' ').Split(' ')

                    }).ToList();
                    break;
            }
            return symptomMap;
        }
    }
}
