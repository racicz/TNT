using System;
using System.Collections.Generic;

namespace TNT.Data.Model
{
    public partial class AutoNumber
    {
        public int Id { get; set; }
        public long? NextOrderNumber { get; set; }
    }
}
