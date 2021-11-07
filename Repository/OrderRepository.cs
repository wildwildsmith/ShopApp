using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Data.Interfaces;
using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ShopDbContext context) : base(context)
        {
        }

        public void CreateOrder(Order order)
        {
            Create(order);
        }

        public void DeleteOrder(Order order)
        {
            Delete(order);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(bool includeItems, bool trackChanges)
        {
            if (includeItems)
            {
                return await FindAll(include: o => o.Include(i => i.Items).ThenInclude(p => p.Product), trackChanges)
                    .OrderBy(o => o.OrderDate)
                    .ToListAsync();
            }
            else
            {
                return await FindAll(trackChanges).OrderBy(o => o.OrderNumber).ToListAsync();
            }
        }

        public async Task<Order> GetOrderByIdAsync(Guid id, string username, bool includeItems, bool trackChanges)
        {
            if (includeItems)
            {
                return await FindByCondition(include: o => o.Include(i => i.Items).ThenInclude(p => p.Product), 
                    expression: o => o.Id.Equals(id) && o.User.UserName == username, trackChanges)
                    .SingleOrDefaultAsync();
            }
            else
            {
                return await FindByCondition(o => o.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserAsync(string username, bool includeItems, bool trackChanges)
        {
            if (includeItems)
            {
                return await FindByCondition(include: o => o.Include(i => i.Items).ThenInclude(p => p.Product),
                    expression: o => o.User.UserName.Equals(username), trackChanges)
                    .OrderBy(o => o.OrderDate)
                    .ToListAsync();
            }
            else
            {
                return await FindByCondition(o => o.User.UserName.Equals(username), trackChanges)
                    .OrderBy(o => o.OrderDate)
                    .ToListAsync();
            }
        }
    }
}
