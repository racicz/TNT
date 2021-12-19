using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Shared.IRepositories;
using TNT.Shared.Model.Login;

namespace TNT.Business.Interfaces
{
    public interface ILogin:IRepository<LoginDTO, LoginResponseDTO>
    {
    }
}
