using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi.Models.ApiResponse
{
    public class ApiNotFoundRequestResponse : ApiResponse
    {
        public ApiNotFoundRequestResponse(int statusCode, string message = null) : base(statusCode, message)
        {
        }
    }
}
