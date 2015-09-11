using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Healthcare.Model
{
    public class BodyMap : BaseMap
    {
        public BodyMap()
        { }

        public int place { get; set; }
        public List<Place> places { get; set; }
        
    }
}
