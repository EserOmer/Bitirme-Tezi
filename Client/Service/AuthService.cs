using Blazored.SessionStorage;
using Client.AuthDtos;
using Client.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Service
{
    public class AuthService : ServiceBase,IAuthService
    {

        public AuthService(HttpClient httpClient, ISessionStorageService sessionStorage) : base(httpClient, sessionStorage)
        {

        }


        public async Task<Response<LoginResultDto>> Authenticate(LoginDto loginRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/Login", loginRequest);

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Response<LoginResultDto>>(resultString);

            if (result.HasError)
            {
                throw result.Error;
            }

            return result;
        }

        public async Task<CurrentUser> CurrentUserInfo()
        {
            var result = await _httpClient.GetFromJsonAsync<CurrentUser>("api/account/GetCurrentUserInfo");
            return result;

        }

        public async Task Logout()
        {
            var result = await _httpClient.PostAsync("api/auth/logout", null);
            result.EnsureSuccessStatusCode();
        }

        public async Task Register(RegisterDto registerRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/register", registerRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }
    }
}
