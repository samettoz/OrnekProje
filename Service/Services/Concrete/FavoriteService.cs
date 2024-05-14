using Core.Repository;
using Dto.Request;
using Dto.Response;
using DtoMapper;
using Entity;
using Microsoft.EntityFrameworkCore;
using Service.Context;
using Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Concrete
{
    public class FavoriteService : IFavoriteService
    {
        IEntityRepositoryBase<Favorite> _favoriteRepository;
       
        public FavoriteService(IEntityRepositoryBase<Favorite> favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
           
        }

        public async Task AddAsync(FavoriteRequestDto dto)
        {
            var favorite = FavoriteDtoMapper.MapToEntity(dto);
            await _favoriteRepository.AddAsync(favorite);
        }

        public async Task DeleteAsync(int id)
        {
            await _favoriteRepository.DeleteAsync(id);
        }

        public async Task<List<ProductResponseDto>> GetFavoriteProductsAsync(int userId)
        {
            using (ECommerceDbContext context = new())
            {
                var favoriteProductsIds = await context.Favorites.Where(f => f.UserId == userId).Select(f => f.ProductId).ToListAsync();
                var favoriteProducts = await context.Products.Where(p => favoriteProductsIds.Contains(p.Id)).ToListAsync();
                return favoriteProducts.Select (fp => ProductDtoMapper.MapToDto(fp)).ToList();
            }
        }
    }
}
