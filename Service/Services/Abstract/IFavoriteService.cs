using Dto.Request;
using Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Abstract
{
    public interface IFavoriteService
    {
        Task AddAsync(FavoriteRequestDto dto);
        Task DeleteAsync(int id);
        Task<List<ProductResponseDto>> GetFavoriteProductsAsync(int userId);
    }
}
