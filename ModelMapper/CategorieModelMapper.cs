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
    public static class CategorieModelMapper
    {
        public static CategorieRequestDto MapToDto(CategorieRequestModel model)
        {
            if (model == null)
                return null;

            return new CategorieRequestDto
            {
                CategorieName = model.CategorieName,
            };
        }

        public static CategorieResponseModel MapToModel(CategorieResponseDto dto)
        {
            if (dto == null)
                return null;

            return new CategorieResponseModel
            {
                Id = dto.Id,
                CategorieName = dto.CategorieName
            };
        }

        public static UpdateCategorieRequestDto MapToUpdateRequestDto(UpdateCategorieRequestModel model)
        {
            if (model == null)
                return null;

            return new UpdateCategorieRequestDto
            {
                Id = model.Id,
                CategorieName = model.CategorieName,
            };
        }
    }
}
