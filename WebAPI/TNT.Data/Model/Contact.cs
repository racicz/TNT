using System;
using System.Collections.Generic;

namespace TNT.Data.Model
{
    public partial class Contact
    {
        public int SubjectContactId { get; set; }
        public int SubjectId { get; set; }
        public int SubjectContactTypeId { get; set; }
        public string ContactValue { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual SubjectContactType SubjectContactType { get; set; }
    }
}
