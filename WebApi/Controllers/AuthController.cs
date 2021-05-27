using Business.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<Response<LoginResultDto>> Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return await Response<LoginResultDto>.Catch(new ResponseError() { Message = "Sifre Yanlis" });
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return await Response<LoginResultDto>.Run(new LoginResultDto() { AccessToken = result.Data.Token });
            }

            return await Response<LoginResultDto>.Catch(new ResponseError() { Message = "Bad Request" });
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest("Kullanici Mevcut");
            }
           
            try
            {
                var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //public ActionResult Register(UserForRegisterDto userForRegisterDto)
        //{
        //    var userExists = _authService.UserExists(userForRegisterDto.Email);
        //    if (!userExists.Success)
        //    {
        //        return BadRequest(userExists.Message);
        //    }

        //    var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
        //    var result = _authService.CreateAccessToken(registerResult.Data);
        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }

        //    return BadRequest(result.Message);
        //}
    }



    public class LoginResultDto
    {
        public string AccessToken { get; set; }

        public string EncryptedAccessToken { get; set; }

        public int ExpireInSeconds { get; set; }

        public long UserId { get; set; }

        public string[] Roles { get; set; }
    }

    public class Response<T>
    {
        public int StatusCode { get; set; }

        public IReadOnlyList<T> Results { get; set; }

        public T Result { get; set; }

        public ResponseError Error { get; set; }

        public bool HasError
        {
            get
            {
                return Error != null
;
            }
        }

        public static async Task<Response<T>> Run(T data, int statusCode = 200)
        {
            return await Task.FromResult(new Response<T> { Result = data, StatusCode = statusCode });
        }
        public static async Task<Response<T>> Catch(ResponseError error, int? errorCode = null)
        {
            return await Task.FromResult(new Response<T> { Error = error, StatusCode = (errorCode.HasValue) ? errorCode.Value : error.Code });
        }
    }

    public class ResponseError : Exception
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
