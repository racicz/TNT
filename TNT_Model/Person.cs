using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT_Model
{
    public class Person
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
    }
}
