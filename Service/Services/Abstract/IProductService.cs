using Dto.Request;
using Dto.Response;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Abstract
{
    public interface IProductService
    {
        Task AddAsync(ProductRequestDto dto);
        Task UpdateAsync(UpdateProductRequestDto dto);
        Task DeleteAsync(int id);
        Task<ProductResponseDto> GetByIdAsync(int id);
        Task<List<ProductResponseDto>> GetProductByCategorie(int categorieId);
        Task<List<ProductResponseDto>> GetAllAsync();
    }
}
