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
    public static class FavoriteDtoMapper
    {
        public static FavoriteResponseDto MapToDto(Favorite favorite)
        {
            if (favorite == null)
                return null;

            return new FavoriteResponseDto
            {
                Id = favorite.Id,
                ProductId = favorite.ProductId,
                UserId = favorite.UserId
            };
        }

        public static Favorite MapToEntity(FavoriteRequestDto dto)
        {
            if (dto == null)
                return null;

            return new Favorite
            {
                ProductId = dto.ProductId,
                UserId = dto.UserId
            };
        }

        public static Favorite MapUpdateFavoriteRequestDtoToEntity(UpdateFavoriteRequestDto dto)
        {
            if (dto == null)
                return null;

            return new Favorite
            {
                Id = dto.Id,
                ProductId = dto.ProductId,
                UserId = dto.UserId
            };
        }

    }
}
