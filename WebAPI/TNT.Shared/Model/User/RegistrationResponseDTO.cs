using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Shared.Model.Base;

namespace TNT.Shared.Model.User
{
    public partial class RegistrationResponseDTO: BaseResponse
    {
        public bool IsSuccessfulRegistration { get; set; }
    }
}
