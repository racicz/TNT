using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT_Model
{
    public class FishType
    {
        public int FishTypeId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string PrepSelected { get; set; }
        public virtual List<Preparation> Preparations { get; set; }
    }
}
