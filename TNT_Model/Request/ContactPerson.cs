using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT_Model
{
    public class ContactPerson
    {
        public int LastOrderNumber { get; set; }
        public Person Person { get; set; }
        public Contact Contact { get; set; }
    }
}
