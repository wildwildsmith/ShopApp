using ShopApp.Data;
using ShopApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ShopDbContext context;
        private IOrderRepository orderRepository;
        private IProductRepository productRepository;

        public RepositoryManager(ShopDbContext context)
        {
            this.context = context;
        }

        public IOrderRepository Order
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(context);
                }

                return orderRepository;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(context);
                }

                return productRepository;
            }
        }

        public Task SaveAsync() => context.SaveChangesAsync();
    }
}
