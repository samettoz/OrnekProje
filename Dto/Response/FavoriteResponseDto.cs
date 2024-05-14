using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Response
{
    public class FavoriteResponseDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
