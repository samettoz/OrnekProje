using Core.Result;
using Model.Request;
using Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFavoriteBusiness
    {
        Task<IResult> AddAsync(FavoriteRequestModel model);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<List<ProductResponseModel>>> GetFavoriteProductsAsync(int userId);
    }
}
