using Core.Result;
using Dto.Response;
using Model.Request;
using Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductBusiness
    {
        Task<IResult> AddAsync(ProductRequestModel model);
        Task<IResult> UpdateAsync(UpdateProductRequestModel model);
        Task<IResult> DeleteAsync(int id);
        Task<IDataResult<List<ProductResponseModel>>> GetAllAsync();
        Task<IDataResult<ProductResponseModel>> GetByIdAsync(int id);
        Task<IDataResult<List<ProductResponseModel>>> GetProductByCategorie(int categorieId);
    }
}
