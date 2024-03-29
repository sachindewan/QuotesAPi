﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QuotesApi.Models.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi.Filters
{
    public class ModelValidationFilterAttribute
    {
        public class ApiValidationFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                if (!context.ModelState.IsValid)
                {
                    context.Result = new BadRequestObjectResult(new ApiBadRequestResponse(context.ModelState));
                }

                base.OnActionExecuting(context);
            }
        }
    }
}
