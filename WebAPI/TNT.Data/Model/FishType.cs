using System;
using System.Collections.Generic;

namespace TNT.Data.Model
{
    public partial class FishType
    {
        public FishType()
        {
            FishTypePreparations = new HashSet<FishTypePreparation>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int FishTypeId { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<FishTypePreparation> FishTypePreparations { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
