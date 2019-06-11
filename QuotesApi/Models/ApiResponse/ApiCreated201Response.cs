using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi.Models.ApiResponse
{
    public class ApiCreated201Response : ApiResponse
    {
        public ApiCreated201Response(int statusCode, string message = null) : base(statusCode, message)
        {
        }
    }
}
