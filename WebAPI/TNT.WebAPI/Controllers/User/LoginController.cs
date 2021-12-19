using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNT.Business.Interfaces;
using TNT.Shared.Model;
using TNT.Shared.Model.Login;

namespace TNT.WebAPI.Controllers.User
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : RestController<LoginDTO,LoginResponseDTO>
    {
        private readonly ILogin repo;
        public LoginController(ILogin repository)
            : base(repository)
        {
            repo = repository;
        }
    }
}
