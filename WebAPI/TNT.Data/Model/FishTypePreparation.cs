using System;
using System.Collections.Generic;

namespace TNT.Data.Model
{
    public partial class FishTypePreparation
    {
        public int Id { get; set; }
        public int FishTypeId { get; set; }
        public int PreparationId { get; set; }
        public bool Deleted { get; set; }

        public virtual FishType FishType { get; set; }
        public virtual Preparation Preparation { get; set; }
    }
}
