using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Response
{
    public class FavoriteResponseModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
