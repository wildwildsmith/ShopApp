using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.Models
{
    public class User : IdentityUser<Guid>
    {
        [Required(ErrorMessage = "First name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the First name is 30 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Last name is 30 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "City is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the City is 30 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
        public string Address { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
