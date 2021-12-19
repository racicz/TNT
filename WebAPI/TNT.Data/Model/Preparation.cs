using System;
using System.Collections.Generic;

namespace TNT.Data.Model
{
    public partial class Preparation
    {
        public Preparation()
        {
            FishTypePreparations = new HashSet<FishTypePreparation>();
            OrderDetailPreparations = new HashSet<OrderDetailPreparation>();
        }

        public int PreparationId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FishTypePreparation> FishTypePreparations { get; set; }
        public virtual ICollection<OrderDetailPreparation> OrderDetailPreparations { get; set; }
    }
}
