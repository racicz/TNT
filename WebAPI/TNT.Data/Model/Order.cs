using System;
using System.Collections.Generic;

namespace TNT.Data.Model
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int SubjectId { get; set; }
        public int OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
