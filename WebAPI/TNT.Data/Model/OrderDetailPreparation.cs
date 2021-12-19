using System;
using System.Collections.Generic;

namespace TNT.Data.Model
{
    public partial class OrderDetailPreparation
    {
        public int OrderDetailPreparationId { get; set; }
        public int PreparationId { get; set; }
        public int? OrderDetailId { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
        public virtual Preparation Preparation { get; set; }
    }
}
