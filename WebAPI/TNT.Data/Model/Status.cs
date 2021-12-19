using System;
using System.Collections.Generic;

namespace TNT.Data.Model
{
    public partial class Status
    {
        public Status()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int StatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
