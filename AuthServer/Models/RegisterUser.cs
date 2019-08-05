using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Models
{
    public class RegisterUser
    {
        public string client_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string connection { get; set; }
    }
}
