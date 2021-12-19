using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNT.Business.Interfaces.User;
using TNT.Data.Model;
using TNT.EmailService;
using TNT.Shared;
using TNT.Shared.Enum;
using TNT.Shared.Messages;
using TNT.Shared.Model.User;

namespace TNT.Business.Repositories
{
    public  class UserRepository : IUser
    {
        private TNTContext _tntContext;
        private UserManager<User> _userManager;
        private IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public UserRepository(TNTContext tntContext, UserManager<User> userManager, IMapper mapper, IEmailSender emailSender) 
        {
            _userManager = userManager;
            _mapper = mapper;
            _tntContext = tntContext;
            _emailSender = emailSender;
        }

        public async Task<RepositoryResponse<RegistrationResponseDTO>> CreateAsync(RegistrationDTO entity)
        {

            try
            {
                var user = _mapper.Map<User>(entity);

                var result = await _userManager.CreateAsync(user, entity.Password);
                if (!result.Succeeded)
                    return RepositoryResponse<RegistrationResponseDTO>.Failure(result.Errors);


                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var param = new Dictionary<string, string>
                {
                    {"token", token },
                    {"email", user.Email }
                };

                //var callback = QueryHelpers.AddQueryString(entity.ClientURI, param);

                //var message = new Message(new string[] { "codemazetest@gmail.com" }, "Email Confirmation token", callback, null);
                //await _emailSender.SendEmailAsync(message);
                //await _userManager.AddToRoleAsync(user, Constant.AdminRole);

                return RepositoryResponse<RegistrationResponseDTO>.Success(new RegistrationResponseDTO() { IsSuccessfulRegistration = true}, RepositoryActionStatus.Created);
            }
            catch (Exception ex)
            {
                return RepositoryResponse<RegistrationResponseDTO>.Failure(ex.Message);
            }
        }
    }
}
