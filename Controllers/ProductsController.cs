using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using ShopApp.ActionFilters;
using ShopApp.Data.Interfaces;
using ShopApp.Entities.DTO.ProductsDto;
using ShopApp.Entities.Models;
using ShopApp.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    [Produces("application/json")]
    [ResponseCache(CacheProfileName = "100Sec")]
    public class ProductsController : ControllerBase
    {
        private readonly IRepositoryManager repository;
        private readonly IMapper mapper;
        private readonly ILogger<ProductsController> logger;
        private readonly LinkGenerator linkGenerator;

        public ProductsController(IRepositoryManager repository, IMapper mapper, 
            ILogger<ProductsController> logger, LinkGenerator linkGenerator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet(Name = "GetProducts")]
        [HttpHead]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParameters productParameters)
        {
            if (!productParameters.ValidPriceRange)
            {
                return BadRequest("Max price can't be less than min price");
            }

            var products = await repository.Product.GetAllProductsAsync(productParameters, trackChanges: false);
            var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(productsDto);
        }

        [HttpGet("{id}", Name = "PoductById")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await repository.Product.GetProductAsync(id, trackChanges: false);

            if (product == null)
            {
                logger.LogInformation($"Product with id: {id} doesn't exist");
                return NotFound();
            }
            else
            {
                var productDto = mapper.Map<ProductDto>(product);
                return Ok(productDto);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto productDto)
        {
            var productEntity = mapper.Map<Product>(productDto);

            repository.Product.CreateProduct(productEntity);
            await repository.SaveAsync();

            var productToReturn = mapper.Map<ProductDto>(productEntity);

            return CreatedAtRoute("PoductById", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateProductExistAttribute))]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductForUpdateDto productDto)
        {
            var productEntity = HttpContext.Items["product"] as Product;

            mapper.Map(productDto, productEntity);
            await repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidateProductExistAttribute))]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productEntity = HttpContext.Items["product"] as Product;

            repository.Product.DeleteProduct(productEntity);
            await repository.SaveAsync();

            return NoContent();
        }
    }
}
