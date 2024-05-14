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
    public static class ProductModelMapper
    {
        public static ProductRequestDto MapToDto(ProductRequestModel model)
        {
            if (model == null)
                return null;


            return new ProductRequestDto
            {
                ProductName = model.ProductName,
                CategoryId = model.CategoryId,
                UnitPrice = model.UnitPrice,
                QuantityPerUnit = model.QuantityPerUnit
            };
        }

        public static ProductResponseModel MapToModel(ProductResponseDto dto)
        {
            if (dto == null)
                return null;


            return new ProductResponseModel
            {
                Id = dto.Id,
                ProductName = dto.ProductName,
                CategoryId = dto.CategoryId,
                UnitPrice = dto.UnitPrice,
                QuantityPerUnit = dto.QuantityPerUnit

            };
        }

        public static UpdateProductRequestDto MaptoUpdateRequestDto(UpdateProductRequestModel model)
        {
            if (model == null)
                return null;

            return new UpdateProductRequestDto
            {
                Id = model.Id,
                ProductName = model.ProductName,
                CategoryId = model.CategoryId,
                UnitPrice = model.UnitPrice,
                QuantityPerUnit = model.QuantityPerUnit
            };
        }
    }
}

