using System;
using System.Collections.Generic;

namespace TNT.Data.Model
{
    public partial class Town
    {
        public Town()
        {
            Subjects = new HashSet<Subject>();
        }

        public int TownId { get; set; }
        public string TownName { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
