using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using QuotesApi.Models.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace QuotesApi.Middlewares
{
    public class ErrorWrappingMiddleware
    {
        public RequestDelegate _next;

        public static Formatting JsonFormatter { get; private set; }

        public ErrorWrappingMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch(Exception ex)
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await HandleExceptionAsync(httpContext, ex);
            }
            if (!httpContext.Response.HasStarted)
            {
                await HandleExceptionAsync(httpContext, null);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception) //[TODO: enhanced this method to handke all types of error]
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)context.Response.StatusCode;
            var response = new ApiResponse(context.Response.StatusCode,  ((HttpStatusCode)context.Response.StatusCode).ToString());
            var json = JsonConvert.SerializeObject(response,new JsonSerializerSettings() {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            return context.Response.WriteAsync(json);
        }
    }
}
