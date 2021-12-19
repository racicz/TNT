using System;
using System.Collections.Generic;

namespace TNT.Data.Model
{
    public partial class SubjectContactType
    {
        public SubjectContactType()
        {
            Contacts = new HashSet<Contact>();
        }

        public int SubjectContactTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
