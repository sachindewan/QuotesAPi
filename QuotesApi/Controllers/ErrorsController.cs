using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotesApi.Models.ApiResponse;

namespace QuotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("{code}")]
        public IActionResult Error(int code)
        {
            HttpStatusCode statusCodes = (HttpStatusCode)code;
            var apiRes = new ApiResponse(code, statusCodes.ToString());
            return new ObjectResult(apiRes);
        }
    }
}