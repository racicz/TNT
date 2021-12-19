using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Shared.IRepositories;
using TNT.Shared.Model.User;

namespace TNT.Business.Interfaces.User
{
    public interface IUser : IRepository<RegistrationDTO, RegistrationResponseDTO>
    {
    }
}
