using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using ShopApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.ActionFilters
{
    public class ValidateProductExistAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager repository;
        private readonly ILogger<ValidateProductExistAttribute> logger;

        public ValidateProductExistAttribute(IRepositoryManager repository, ILogger<ValidateProductExistAttribute> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
            var id = (int)context.ActionArguments["id"];
            var product = await repository.Product.GetProductAsync(id, trackChanges);

            if (product == null)
            {
                logger.LogInformation($"Product with id: {id} doesn't exist");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("product", product);
                await next();
            }
        }
    }
}
