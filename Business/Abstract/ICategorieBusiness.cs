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
    public interface ICategorieBusiness
    {
        Task<IResult> AddAsync(CategorieRequestModel model);
        Task<IResult> DeleteAsync(int id);
        Task<IResult> UpdateAsync(UpdateCategorieRequestModel model);
        Task<IDataResult<List<CategorieResponseModel>>> GetAllAsync();
        Task<IDataResult<CategorieResponseModel>> GetById(int id);
    }
}
