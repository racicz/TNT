using System;
using System.Collections.Generic;

namespace TNT.Data.Model
{
    public partial class Business
    {
        public int SubjectId { get; set; }
        public string CompanyName { get; set; }
        public string Contact { get; set; }
        public string Town { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
