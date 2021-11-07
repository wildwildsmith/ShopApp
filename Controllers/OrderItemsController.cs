using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopApp.ActionFilters;
using ShopApp.Data.Interfaces;
using ShopApp.Entities.DTO.OrderItemsDto;
using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Controllers
{
    [Route("api/orders/{orderId}/items")]
    [ApiController]
    [Authorize]
    public class OrderItemsController : ControllerBase
    {
        private readonly IRepositoryManager repository;
        private readonly IMapper mapper;
        private readonly ILogger<OrderItemsController> logger;

        public OrderItemsController(IRepositoryManager repository, IMapper mapper,
            ILogger<OrderItemsController> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet(Name = "GetOrderItems")]
        public async Task<IActionResult> GetOrderItems(Guid orderId)
        {
            var username = User.Identity.Name;
            var order = await repository.Order.GetOrderByIdAsync(orderId, username, true, false);

            if(order == null)
            {
                logger.LogInformation($"Order with id: {orderId} doesn't exist");
                return NotFound();
            }
            else
            {
                var orderItemsDto = mapper.Map<IEnumerable<OrderItemDto>>(order.Items);

                return Ok(orderItemsDto);
            }
        }

        [HttpGet("{id}", Name = "GetOrderItemsById")]
        public async Task<IActionResult> GetOrderItemsById(Guid orderId, int id)
        {
            var username = User.Identity.Name;
            var order = await repository.Order.GetOrderByIdAsync(orderId, username, true, false);

            if (order == null)
            {
                logger.LogInformation($"Order with id: {orderId} doesn't exist");
                return NotFound();
            }
            else
            {
                var items = order.Items.Where(o => o.Id.Equals(orderId)).FirstOrDefault();
                var orderItemDto = mapper.Map<OrderItemDto>(items);

                return Ok(orderItemDto);
            }
        }
    }
}
