using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Shared.Model.Base
{
    public partial class BaseResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
