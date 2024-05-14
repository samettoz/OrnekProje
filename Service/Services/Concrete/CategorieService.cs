using Core.Repository;
using Dto.Request;
using Dto.Response;
using DtoMapper;
using Entity;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Concrete
{
    public class CategorieService : ICategorieService
    {
        IEntityRepositoryBase<Categorie> _categorieRepository;
        public CategorieService(IEntityRepositoryBase<Categorie> categorieRepository)
        {
            _categorieRepository = categorieRepository;
        }

        public async Task AddAsync(CategorieRequestDto dto)
        {
            var categorie = CategorieDtoMapper.MapToEntity(dto);
            await _categorieRepository.AddAsync(categorie);

        }

        public async Task DeleteAsync(int id)
        {
            await _categorieRepository.DeleteAsync(id);
        }

        public async Task<List<CategorieResponseDto>> GetAllAsync()
        {
            var categories = await _categorieRepository.GetAllAsync();
            return categories.Select(categorie => CategorieDtoMapper.MapToDto(categorie)).ToList();
        }

        public async Task<CategorieResponseDto> GetByIdAsync(int id)
        {
            var categorie = await _categorieRepository.GetAsync(c => c.Id == id);
            return CategorieDtoMapper.MapToDto(categorie);
        }

        public async Task UpdateAsync(UpdateCategorieRequestDto dto)
        {
            var categorie = CategorieDtoMapper.MapUpdateCategorieRequestDtoToEntity(dto);
            await _categorieRepository.UpdateAsync(categorie);
        }
    }
}
