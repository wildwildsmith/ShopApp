using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Data.Interfaces
{
    public interface IRepositoryManager
    {
        IOrderRepository Order { get; }
        IProductRepository Product { get; }
        Task SaveAsync();
    }
}
