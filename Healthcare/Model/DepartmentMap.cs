using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Model
{
    public class DepartmentMap : BaseMap
    {
        public int department { get; set; }
        public List<Department> departments { get; set; }
    }
}
