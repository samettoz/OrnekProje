using Core.Result;
using Model.Request;
using Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserBusiness
    {
        Task<IResult> AddAsync(UserRequestModel model);
        Task<IResult> UpdateAsync(UpdateUserRequestModel model);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<List<UserResponseModel>>> GetAllAsync();
        Task<IDataResult<UserResponseModel>> GetByIdAsync(int id);
    }
}
