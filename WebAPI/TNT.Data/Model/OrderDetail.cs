using System;
using System.Collections.Generic;

namespace TNT.Data.Model
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            OrderDetailPreparations = new HashSet<OrderDetailPreparation>();
        }

        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int FishTypeId { get; set; }
        public int StatusId { get; set; }
        public decimal OrderKg { get; set; }
        public decimal? PricePerKg { get; set; }
        public decimal DeliveredKg { get; set; }
        public string Notes { get; set; }
        public decimal AmountDue { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool Deleted { get; set; }

        public virtual FishType FishType { get; set; }
        public virtual Order Order { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<OrderDetailPreparation> OrderDetailPreparations { get; set; }
    }
}
