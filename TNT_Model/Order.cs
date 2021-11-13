using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT_Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public virtual int SubjectId { get; set; }
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public virtual Person Person { get; set; }
        public string Action { get; set; }

    }
}
