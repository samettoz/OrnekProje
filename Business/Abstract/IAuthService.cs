using Core.Result;
using Core.Security;
using Dto.Request;
using Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Token> Login(UserLoginRequestModel model);
        IDataResult<UserRequestDto> Register(UserRegisterRequestModel model);
    }
}
