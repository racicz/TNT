using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNT.Business.Interfaces.User;
using TNT.Shared.Model.User;

namespace TNT.WebAPI.Controllers.User
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : RestController<RegistrationDTO, RegistrationResponseDTO>
    {
        private readonly IUser repo;
        public RegistrationController(IUser repository)
            : base(repository)
        {
            repo = repository;
        }
        
    }
}
