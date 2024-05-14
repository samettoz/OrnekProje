using Business.Abstract;
using Core.Result;
using Core.Security;
using Dto.Request;
using Entity;
using Microsoft.Extensions.Configuration;
using Model.Request;
using ModelMapper;
using Service.Services.Abstract;
using Service.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly ITokenHandler _tokenHandler;
        IConfiguration _configuration;
        IUserService _userService;

        public AuthService(ITokenHandler tokenHandler, IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }


        public IDataResult<Token> Login(UserLoginRequestModel model)
        {

            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return new ErrorDataResult<Token>();
            }

            var userEmail = _configuration["User:Email"];
            var userPassword = _configuration["User:Password"];
            var adminEmail = _configuration["Admin:Email"];
            var adminPassword = _configuration["Admin:Password"];


            if (model.Email == userEmail && model.Password == userPassword)
            {
                var token = _tokenHandler.CreateToken();
                return new SuccessDataResult<Token>(token);
            }
            else if (model.Email == adminEmail && model.Password == adminPassword)
            {
                var token = _tokenHandler.CreateToken();
                return new SuccessDataResult<Token>(token);
            }
            else
            {
                return new ErrorDataResult<Token>("Geçersiz e-posta veya şifre.");
            }
        }

        public IDataResult<UserRequestDto> Register(UserRegisterRequestModel model)
        {
            var user = new UserRequestDto
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                Role = UserRole.User
            };


            _userService.AddAsync(user);
            return new SuccessDataResult<UserRequestDto>(user);
        }


    }
}
