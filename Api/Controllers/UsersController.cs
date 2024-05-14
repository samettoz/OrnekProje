using Business.Abstract;
using Business.Concrete;
using Core.Result;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;
using IResult = Core.Result.IResult;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserBusiness _userBusiness;
        public UsersController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        public async Task<IDataResult<List<UserResponseModel>>> GetAll()
        {
            return await _userBusiness.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IDataResult<UserResponseModel>> GetById(int id)
        {
            return await _userBusiness.GetByIdAsync(id);
        }



        [HttpPost]
        public async Task<IResult> Add(UserRequestModel model)
        {
            return await _userBusiness.AddAsync(model);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            return await _userBusiness.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<IResult> Update(UpdateUserRequestModel model)
        {
            return await _userBusiness.UpdateAsync(model);
        }
    }
}
