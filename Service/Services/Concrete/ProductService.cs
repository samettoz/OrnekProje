using Core.Repository;
using Core.Result;
using Core.Validation;
using Core.Validation.ValidationRules;
using Dto.Request;
using Dto.Response;
using DtoMapper;
using Entity;
using Entity.Abstract;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Concrete
{
    public class ProductService : IProductService
    {
        IEntityRepositoryBase<Product> _productRepository;
        public ProductService(IEntityRepositoryBase<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task AddAsync(ProductRequestDto dto)
        {
            var entity = ProductDtoMapper.MapToEntity(dto);

            ValidationTool.Validate(new ProductValidator(), entity);
            await _productRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(product => ProductDtoMapper.MapToDto(product)).ToList();
        }

        public async Task<ProductResponseDto> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetAsync(p => p.Id == id);
            return ProductDtoMapper.MapToDto(product);
        }


        public async Task<List<ProductResponseDto>> GetProductByCategorie(int categorieId)
        {
            var products = await _productRepository.GetAllAsync(p => p.CategoryId == categorieId);
            return products.Select(product => ProductDtoMapper.MapToDto(product)).ToList();
        }


        public async Task UpdateAsync(UpdateProductRequestDto dto)
        {

            var updatedEntity = ProductDtoMapper.MapUpdateProductRequestDtoToEntity(dto);
            ValidationTool.Validate(new ProductValidator(), updatedEntity);

            await _productRepository.UpdateAsync(updatedEntity);
        }

       
    }
}
