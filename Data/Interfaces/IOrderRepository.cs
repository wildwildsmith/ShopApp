using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync(bool includeItems, bool trackChanges);
        Task<IEnumerable<Order>> GetOrdersByUserAsync(string username, bool includeItems, bool trackChanges);
        Task<Order> GetOrderByIdAsync(Guid Id, string username, bool includeItems, bool trackChanges);
        void CreateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
