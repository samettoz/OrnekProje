using Business.Abstract;
using Core.Result;
using IResult = Core.Result.IResult;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductBusiness _productBusiness;
        public ProductsController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [HttpGet("{categorieId}")]
        public async Task<IDataResult<List<ProductResponseModel>>> GetProductByCategorie(int categorieId)
        {
            return await _productBusiness.GetProductByCategorie(categorieId);

        }


        [HttpGet]
        public async Task<IDataResult<List<ProductResponseModel>>> GetAll()
        {
            return await _productBusiness.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IDataResult<ProductResponseModel>> GetById(int id)
        {
            return await _productBusiness.GetByIdAsync(id);
        }



        [HttpPost]
        //[Authorize(Roles ="admin")]
        public async Task<IResult> Add(ProductRequestModel model)
        {
            return await _productBusiness.AddAsync(model);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]

        public async Task<IResult> Delete(int id)
        {
            return await _productBusiness.DeleteAsync(id);
        }

        [HttpPut]
        //[Authorize(Roles = "admin")]

        public async Task<IResult> Update(UpdateProductRequestModel model)
        {
            return await _productBusiness.UpdateAsync(model);
        }
    }
}
