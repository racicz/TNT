using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Shared.Model.Login
{
    public class LoginResponseDTO
    {
        public long ApplicationUserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPasssword { get; set; }
        public byte UserStatusMasterId { get; set; }
        public string ApplicationUserName { get; set; }
        public bool TAAgreedByUser { get; set; }
        public string UserRole { get; set; }
        public string Token { get; set; }
    }
}
