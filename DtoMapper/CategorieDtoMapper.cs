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
    public static class CategorieDtoMapper
    {
        public static CategorieResponseDto MapToDto(Categorie categorie)
        {
            if (categorie == null)
                return null;

            return new CategorieResponseDto
            {
                Id = categorie.Id,
                CategorieName = categorie.CategorieName
            };
        }     
        
        public static Categorie MapToEntity(CategorieRequestDto dto)
        {
            if (dto == null)
                return null;

            return new Categorie
            {
                CategorieName = dto.CategorieName,
            };
        }

        public static Categorie MapUpdateCategorieRequestDtoToEntity(UpdateCategorieRequestDto dto)
        {
            if (dto == null)
                return null;

            return new Categorie
            {
                Id = dto.Id,
                CategorieName = dto.CategorieName
            };
        }
    }
}
