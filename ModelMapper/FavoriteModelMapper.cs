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
    public class FavoriteModelMapper
    {
        public static FavoriteRequestDto MapToDto(FavoriteRequestModel model)
        {
            if (model == null)
                return null;

            return new FavoriteRequestDto
            {
                ProductId = model.ProductId,
                UserId = model.UserId,
            };
        }

        public static FavoriteResponseModel MapToModel(FavoriteResponseDto dto)
        {
            if (dto == null)
                return null;

            return new FavoriteResponseModel
            {
                ProductId = dto.ProductId,
                UserId = dto.UserId,
                Id = dto.Id
            };
        }

        public static UpdateFavoriteRequestDto MapToUpdateFavoriteRequestDto(UpdateFavoriteRequestModel model)
        {
            if (model == null)
                return null;

            return new UpdateFavoriteRequestDto()
            {
                Id = model.Id,
                ProductId = model.ProductId,
                UserId = model.UserId
            };
        }
    }
}
