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
        private static CheckServer checkser = new CheckServer();
        private static OperationServer operationser = new OperationServer();
        private static DrugServer drugser = new DrugServer();

        public static List<KeyWordsMap> GetMap(string typeName, string jsonStr)
        {
            List<KeyWordsMap> Map = new List<KeyWordsMap>();
            Dictionary<string, string> result = new Dictionary<string, string>();
            switch (typeName)
            {
                case "Symptom":
                    List<SymptomShowItem> oSymptomList = symptomser.SymptomListDeserializer(jsonStr).ToList();
                    Map = oSymptomList.Select(c => new KeyWordsMap
                    {
                        id = c.id,
                        name = c.name,
                        keywords = c.keywords.TrimEnd(' ').Split(' ')

                    }).ToList();
                    break;
                case "Disease":
                    List<DiseaseShowItem> oDiseaseList = diseaseser.DiseaseListDeserializer(jsonStr).ToList();
                    Map = oDiseaseList.Select(c => new KeyWordsMap
                    {
                        id = c.id,
                        name = c.name,
                        keywords = c.keywords.TrimEnd(' ').Split(' ')

                    }).ToList();
                    break;
                case "Check":
                    List<CheckShowItem> oCheckList = checkser.CheckListDeserializer(jsonStr).ToList();
                    Map = oCheckList.Select(c => new KeyWordsMap
                    {
                        id = c.id,
                        name = c.name,
                        keywords = c.keywords.TrimEnd(' ').Split(' ')

                    }).ToList();
                    break;
                case "Operation":
                    List<OperationShowItem> oOperationList = operationser.OperationShowDeserializer(jsonStr).ToList();
                    Map = oOperationList.Select(c => new KeyWordsMap
                    {
                        id = c.id,
                        name = c.name,
                        keywords = c.keywords.TrimEnd(' ').Split(' ')

                    }).ToList();
                    break;

                case "Drug":
                    List<DrugShowItem> oDrugList = drugser.DrugShowDeserializer(jsonStr).ToList();
                    Map = oDrugList.Select(c => new KeyWordsMap
                    {
                        id = c.id,
                        name = c.name,
                        keywords = c.keywords.TrimEnd(' ').Split(' ')

                    }).ToList();
                    break;
                case "DrugNumber":
                case "DrugCode":
                    DrugShowItem oDrugNumber = new DrugShowItem();
                    oDrugNumber = drugser.DrugObjectDeserializer(jsonStr);
                    Map.Add(new KeyWordsMap()
                    {
                        id = oDrugNumber.id,
                        name = oDrugNumber.name,
                        keywords = oDrugNumber.keywords.TrimEnd(' ').Split(' ')
                    });
                    break;

            }
            return Map;
        }
    }
}
