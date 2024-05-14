using Core.Repository;
using Dto.Request;
using Dto.Response;
using DtoMapper;
using Entity;
using Entity.Abstract;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Concrete
{
    public class UserService : IUserService
    {
        IEntityRepositoryBase<User> _userRepository;
        public UserService(IEntityRepositoryBase<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddAsync(UserRequestDto dto)
        {
            var user = UserDtoMapper.MapToEntity(dto);
            await _userRepository.AddAsync(user);

        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<List<UserResponseDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => UserDtoMapper.MapToDto(user)).ToList();
        }

        public async Task<UserResponseDto> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetAsync(u => u.ID == id);
            return UserDtoMapper.MapToDto(user);
        }

        public async Task UpdateAsync(UpdateUserRequestDto dto)
        {
            var user = UserDtoMapper.MapUpdateUserRequestDtoToEntity(dto);
            await _userRepository.UpdateAsync(user);
        }
    }
}
