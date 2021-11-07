using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Data.Interfaces;
using ShopApp.Entities.Models;
using ShopApp.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApp.Extensions;

namespace ShopApp.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ShopDbContext context) : base(context)
        {

        }
        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            return await FindByCondition((p => p.Price >= productParameters.MinPrice && 
                p.Price <= productParameters.MaxPrice), trackChanges)
                .Search(productParameters.SearchTerm)
                .Sort(productParameters.OrderBy)
                .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
                .Take(productParameters.PageSize)
                .ToListAsync();
        }

        public async Task<Product> GetProductAsync(int productId, bool trackChanges)
        {
            return await FindByCondition(p => p.Id.Equals(productId), trackChanges)
                .SingleOrDefaultAsync();
        }
    }
}
