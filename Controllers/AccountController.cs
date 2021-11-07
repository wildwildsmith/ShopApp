using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopApp.ActionFilters;
using ShopApp.Data.Interfaces;
using ShopApp.Entities.DTO.UserDto;
using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> logger;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IAuthenticationManager authenticationManager;

        public AccountController(ILogger<AccountController> logger, IMapper mapper, 
            UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager,
            IAuthenticationManager authenticationManager)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.authenticationManager = authenticationManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userDto)
        {
            var user = mapper.Map<User>(userDto);

            var result = await userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            var roleResult = await roleManager.RoleExistsAsync("user");

            if (roleResult == false)
            {
                return BadRequest();
            }

            await userManager.AddToRoleAsync(user, "user");
            return StatusCode(201);
        }

        [HttpPost("Login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userDto)
        {
            if(!await authenticationManager.ValidateUser(userDto))
            {
                logger.LogWarning($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                return Unauthorized();
            }

            return Ok(new { Token = await authenticationManager.CreateToken() });
        }
    }
}
