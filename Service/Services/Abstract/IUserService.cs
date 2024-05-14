using Dto.Request;
using Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Abstract
{
    public interface IUserService
    {
        Task AddAsync(UserRequestDto dto);
        Task UpdateAsync(UpdateUserRequestDto dto);
        Task DeleteAsync(int id);
        Task<UserResponseDto> GetByIdAsync(int id);
        Task<List<UserResponseDto>> GetAllAsync();
    }
}
