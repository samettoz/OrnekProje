﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security
{
    public interface ITokenHandler
    {
        Token CreateToken();
        string CreateRefreshToken();
    }
}
