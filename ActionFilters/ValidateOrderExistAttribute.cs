using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using ShopApp.Data.Interfaces;
using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.ActionFilters
{
    public class ValidateOrderExistAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager repository;
        private readonly IHttpContextAccessor httpContext;
        private readonly ILogger<ValidateOrderExistAttribute> logger;

        public ValidateOrderExistAttribute(IRepositoryManager repository, IHttpContextAccessor httpContext, ILogger<ValidateOrderExistAttribute> logger)
        {
            this.repository = repository;
            this.httpContext = httpContext;
            this.logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
            var id = (Guid)context.ActionArguments["id"];
            var username = httpContext.HttpContext.User.Identity.Name;
            var order = await repository.Order.GetOrderByIdAsync(id, username, true, trackChanges);

            if(order == null)
            {
                logger.LogInformation($"Order with id: {id} doesn't exist");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("order", order);
                await next();
            }
        }
    }
}
