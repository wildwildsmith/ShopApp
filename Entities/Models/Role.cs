﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.Models
{
    public class Role : IdentityRole<Guid>
    {
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
