﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 20;
        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string OrderBy { get; set; }
    }
}
