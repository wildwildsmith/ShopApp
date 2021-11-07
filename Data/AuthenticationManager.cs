using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopApp.Data.Interfaces;
using ShopApp.Entities.DTO.UserDto;
using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        private User user;

        public AuthenticationManager(UserManager<User> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration.GetSection("Tokens");
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            user = await userManager.FindByNameAsync(userForAuth.UserName);

            return (user != null && await userManager.CheckPasswordAsync(user, userForAuth.Password));
        }

        public async Task<string> CreateToken()
        {
            var creds = GetSigninCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(creds, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials creds, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken
                (
                    issuer: configuration.GetSection("Issuer").Value,
                    audience: configuration.GetSection("Audience").Value,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await userManager.GetRolesAsync(user);

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSigninCredentials()
        {
            var key = Encoding.UTF8.GetBytes(configuration.GetSection("Key").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
    }
}
