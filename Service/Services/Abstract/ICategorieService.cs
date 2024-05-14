using Dto.Request;
using Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Abstract
{
    public interface ICategorieService
    {
        Task AddAsync(CategorieRequestDto dto);
        Task UpdateAsync(UpdateCategorieRequestDto dto);
        Task DeleteAsync(int id);
        Task<CategorieResponseDto> GetByIdAsync(int id);
        Task<List<CategorieResponseDto>> GetAllAsync();
    }
}
