using Client.AuthDtos;
using Client.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Service
{
    public interface IAuthService
    {
        Task<Response<LoginResultDto>> Authenticate(LoginDto loginRequest);

        Task Register(RegisterDto registerRequest);

        Task Logout();

        Task<CurrentUser> CurrentUserInfo();
    }


  
}
