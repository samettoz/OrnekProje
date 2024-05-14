using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Request
{
    public class UpdateFavoriteRequestDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
