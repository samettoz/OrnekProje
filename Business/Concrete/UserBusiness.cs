using Business.Abstract;
using Core.Result;
using Model.Request;
using Model.Response;
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
    public class UserBusiness : IUserBusiness
    {
        IUserService _userService;
        public UserBusiness(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IResult> AddAsync(UserRequestModel model)
        {
            var dto = UserModelMapper.MapToDto(model);
            await _userService.AddAsync(dto);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<UserResponseModel>>> GetAllAsync()
        {
            var productDtos = await _userService.GetAllAsync();
            var productModels = productDtos.Select(pd => UserModelMapper.MapToModel(pd)).ToList();
            return new SuccessDataResult<List<UserResponseModel>>(productModels);
        }

        public async Task<IDataResult<UserResponseModel>> GetByIdAsync(int id)
        {
            var productDto = await _userService.GetByIdAsync(id);
            return new SuccessDataResult<UserResponseModel>(UserModelMapper.MapToModel(productDto));
        }

        public async Task<IResult> UpdateAsync(UpdateUserRequestModel model)
        {
            var productDto = UserModelMapper.MapToUpdateUserRequestDto(model);
            await _userService.UpdateAsync(productDto);
            return new SuccessResult();
        }
    }
}
