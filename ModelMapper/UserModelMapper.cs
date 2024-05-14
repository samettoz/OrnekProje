using Dto.Request;
using Dto.Response;
using Model.Request;
using Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMapper
{
    public class UserModelMapper
    {
        public static UserRequestDto MapToDto(UserRequestModel model)
        {
            if (model == null)
                return null;

            return new UserRequestDto
            {
               UserName = model.UserName,
               Email = model.Email,
               Password = model.Password,
               Role = model.Role,
            };
        }

        public static UserResponseModel MapToModel(UserResponseDto dto)
        {
            if (dto == null)
                return null;

            return new UserResponseModel
            {
              ID = dto.ID,
              UserName = dto.UserName,
              Role = dto.Role,
              Password = dto.Password,
              Email = dto.Email
            };
        }

        public static UpdateUserRequestDto MapToUpdateUserRequestDto(UpdateUserRequestModel model)
        {
            if (model == null)
                return null;

            return new UpdateUserRequestDto()
            {
               ID = model.ID,
               Email = model.Email,
               Password = model.Password,
               Role = model.Role
            };
        }
    }
}
