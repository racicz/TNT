using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT_Model.Response
{
    public class Response
    {
        public string Msg { get; set; }
        public bool Return { get; set; }
        public int ReturnValue { get; set; }
        public string ReturnString { get; set; }
    }
}
