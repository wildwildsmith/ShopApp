using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public ProductParameters()
        {
            OrderBy = "title";
        }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; } = 99;

        public bool ValidPriceRange => MaxPrice > MinPrice;

        public string SearchTerm { get; set; }
    }
}
