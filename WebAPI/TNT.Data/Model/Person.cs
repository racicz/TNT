using System;
using System.Collections.Generic;

namespace TNT.Data.Model
{
    public partial class Person
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
