﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiPA.Common.Models
{
    public class TokenResponse
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }

        public DateTime ExpirationLocal => Expiration.ToLocalTime();
    }
}
