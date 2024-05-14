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
    public class FavoriteBusiness : IFavoriteBusiness
    {
        IFavoriteService _favoriteService;
        public FavoriteBusiness(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        public async Task<IResult> AddAsync(FavoriteRequestModel model)
        {
            var dto = FavoriteModelMapper.MapToDto(model);
            await _favoriteService.AddAsync(dto);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            await _favoriteService.DeleteAsync(id);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<ProductResponseModel>>> GetFavoriteProductsAsync(int userId)
        {
            var productDtos = await _favoriteService.GetFavoriteProductsAsync(userId);
            var productModels = productDtos.Select(pd => ProductModelMapper.MapToModel(pd)).ToList();
            return new SuccessDataResult<List<ProductResponseModel>>(productModels);
        }
    }
}
