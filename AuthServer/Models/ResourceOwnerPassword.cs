﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Models
{
    public class ResourceOwnerPassword
    {
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string audience { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
    }
}
