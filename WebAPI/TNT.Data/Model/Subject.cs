using System;
using System.Collections.Generic;

namespace TNT.Data.Model
{
    public partial class Subject
    {
        public Subject()
        {
            Contacts = new HashSet<Contact>();
            Orders = new HashSet<Order>();
        }

        public int SubjectId { get; set; }
        public int? TownId { get; set; }
        public string SubjectType { get; set; }

        public virtual Town Town { get; set; }
        public virtual Business Business { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
