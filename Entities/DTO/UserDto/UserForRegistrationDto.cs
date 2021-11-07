using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTO.UserDto
{
    public class UserForRegistrationDto
    {
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(15, ErrorMessage = "Maximum length for the Username is 15 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Minimum length for the Password is 6 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

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
