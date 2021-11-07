using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace ShopApp.Extensions
{
    public static class RepositoryProductExtensions
    {
        public static IQueryable<Product> Search(this IQueryable<Product> products, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return products;

            var lcSearchTerm = searchTerm.Trim().ToLower();

            return products.Where(p => p.Title.ToLower().Contains(lcSearchTerm));
        }

        public static IQueryable<Product> Sort (this IQueryable<Product> products, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
                return products.OrderBy(p => p.Title);

            var orderParams = orderBy.Trim().Split(',');
            var propInfo = typeof(Product).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach(var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propFromQueryName = param.Split(" ")[0];
                var objProp = propInfo.FirstOrDefault(pi => pi.Name.Equals(propFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objProp == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objProp.Name.ToString()} {direction}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(orderQuery))
                return products.OrderBy(p => p.Title);

            return products.OrderBy(orderQuery);
        }
    }
}
