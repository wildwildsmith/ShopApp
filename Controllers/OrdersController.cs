using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopApp.ActionFilters;
using ShopApp.Data.Interfaces;
using ShopApp.Entities.DTO.OrdersDto;
using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Controllers
{
    [Route("api/orders")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IRepositoryManager repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrdersController> logger;
        private readonly UserManager<User> userManager;

        public OrdersController(IRepositoryManager repository, IMapper mapper,
            ILogger<OrdersController> logger, UserManager<User> userManager)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
            this.userManager = userManager;
        }

        [HttpGet("all", Name = "GetAllOrders")]
        public async Task<IActionResult> GetAllOrders(bool includeItems = true)
        {
            var orders = await repository.Order.GetAllOrdersAsync(includeItems, trackChanges: false);
            var ordersDto = mapper.Map<IEnumerable<OrderDto>>(orders);

            return Ok(ordersDto);
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders(bool includeItems = true)
        {
            var username = User.Identity.Name;

            var orders = await repository.Order.GetOrdersByUserAsync(username, includeItems, trackChanges: false);
            var ordersDto = mapper.Map<IEnumerable<OrderDto>>(orders);

            return Ok(ordersDto);
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public async Task<IActionResult> GetOrderById(Guid id, bool includeItems = true)
        {
            var username = User.Identity.Name;

            var order = await repository.Order.GetOrderByIdAsync(id, username, includeItems, trackChanges: false);

            if (order == null)
            {
                logger.LogInformation($"Product with id: {id} doesn't exist");
                return NotFound();
            }
            else
            {
                var orderDto = mapper.Map<OrderDto>(order);
                return Ok(orderDto);
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateOrder([FromBody] OrderForCreationDto orderDto)
        {
            var orderEntity = mapper.Map<Order>(orderDto);

            if (orderEntity.OrderDate == DateTime.MinValue)
            {
                orderEntity.OrderDate = DateTime.Now;
            }

            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
            orderEntity.User = currentUser;

            repository.Order.CreateOrder(orderEntity);
            await repository.SaveAsync();

            var orderToReturn = mapper.Map<OrderDto>(orderEntity);

            return CreatedAtRoute("GetOrderById", new { id = orderToReturn.Id }, orderToReturn);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateOrderExistAttribute))]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody]OrderForUpdateDto orderDto)
        {
            var orderEntity = HttpContext.Items["order"] as Order;

            mapper.Map(orderDto, orderEntity);
            await repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateOrderExistAttribute))]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var orderEntity = HttpContext.Items["order"] as Order;

            repository.Order.DeleteOrder(orderEntity);
            await repository.SaveAsync();

            return NoContent();
        }
    }
}
