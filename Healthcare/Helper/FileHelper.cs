using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Windows.Storage;

namespace Healthcare.Helper
{
    class FileHelper
    {
        public static async Task<List<Model.KeyWordsMap>> ReadMap()
        {
            var storage = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync("symptom.xml");
            string readStr = await FileIO.ReadTextAsync(storage);
            XDocument xd = XDocument.Parse(readStr);
            XmlSerializer ser = new XmlSerializer(typeof(List<Model.KeyWordsMap>), new XmlRootAttribute("SymptomMaps"));
            XmlReader xr = xd.CreateReader();
            List<Model.KeyWordsMap> obs = (List<Model.KeyWordsMap>)ser.Deserialize(xr);
            return obs;
        }

    }
}
