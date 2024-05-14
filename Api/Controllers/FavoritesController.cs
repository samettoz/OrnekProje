using Business.Abstract;
using Core.Result;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;
using IResult = Core.Result.IResult;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        IFavoriteBusiness _favoriteBusiness;
        public FavoritesController(IFavoriteBusiness favoriteBusiness)
        {
            _favoriteBusiness = favoriteBusiness;
        }

        [HttpPost]
        public async Task<IResult> Add(FavoriteRequestModel model)
        {
            return await _favoriteBusiness.AddAsync(model);
        }

        [HttpGet("{userId}")]
        public async Task<IDataResult<List<ProductResponseModel>>> GetFavoriteProducts(int userId)
        {
            return await _favoriteBusiness.GetFavoriteProductsAsync(userId);
        }

        [HttpDelete("id")]
        public async Task<IResult> Remove(int id)
        {
            return await _favoriteBusiness.DeleteAsync(id);
        }
    }
}
