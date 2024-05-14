using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public string RefreshToken { get; set; }


    }
}
