using Dto.Request;
using Dto.Response;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoMapper
{
    public static class UserDtoMapper
    {
        public static UserResponseDto MapToDto(User user)
        {
            if (user == null)
                return null;

            return new UserResponseDto
            {
                ID = user.ID,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };
        }

        public static User MapToEntity(UserRequestDto dto)
        {
            if(dto == null)
                return null;

            return new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Role = dto.Role,
                Password = dto.Password
            };
        }

        public static User MapUpdateUserRequestDtoToEntity(UpdateUserRequestDto dto)
        {
            if (dto == null)
                return null;

            return new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password,
                ID = dto.ID,
                Role = dto.Role
            };
        }
    }
}
