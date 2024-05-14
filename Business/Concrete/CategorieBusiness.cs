using Business.Abstract;
using Core.Result;
using Model.Request;
using Model.Response;
using ModelMapper;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategorieBusiness : ICategorieBusiness
    {
        ICategorieService _categorieService;

        public CategorieBusiness(ICategorieService categorieservice)
        {
            _categorieService = categorieservice;
        }
        public async Task<IResult> AddAsync(CategorieRequestModel model)
        {
            var categorieDto = CategorieModelMapper.MapToDto(model);
            await _categorieService.AddAsync(categorieDto);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            await _categorieService.DeleteAsync(id);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<CategorieResponseModel>>> GetAllAsync()
        {
            var categorieDtos = await _categorieService.GetAllAsync();
            var categorieModels = categorieDtos.Select(categorieDto => CategorieModelMapper.MapToModel(categorieDto)).ToList();
            return new SuccessDataResult<List<CategorieResponseModel>>(categorieModels);
        }

        public async Task<IDataResult<CategorieResponseModel>> GetById(int id)
        {
            var categorieDto = await _categorieService.GetByIdAsync(id);
            return new SuccessDataResult<CategorieResponseModel>(CategorieModelMapper.MapToModel(categorieDto));
        }

        public async Task<IResult> UpdateAsync(UpdateCategorieRequestModel model)
        {
            var categorieDto = CategorieModelMapper.MapToUpdateRequestDto(model);
            await _categorieService.UpdateAsync(categorieDto);
            return new SuccessResult();
        }

    }
}
