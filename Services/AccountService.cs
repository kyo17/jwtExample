using System.Text;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwt.Database;
using jwt.Interfaces;
using jwt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace jwt.Services
{
    public class AccountService : IAccount
    {
        private readonly DataContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration config;

        public AccountService(DataContext context, UserManager<IdentityUser> userManager,
        IConfiguration config)
        {
            this.context = context;
            this.userManager = userManager;
            this.config = config;
        }

    
        public async Task<ResponseAuthentication> register(Credentials credentials)
        {
            var user = new IdentityUser{UserName = credentials.nickName, Email = credentials.email};
            var response = await userManager.CreateAsync(user);
            if (response.Succeeded)
            {
                return generateToken(credentials);
            }else
            {
                System.Console.WriteLine(response.Errors);
                throw new Exception("Error a la hora de logear");
            }
        }

        private ResponseAuthentication generateToken(Credentials credentials){
            var claims = new List<Claim>() {
                new Claim("email", credentials.email)
            };

            var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtKey"]));

            var credential = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddHours(1);

            var jwtSecurity = new JwtSecurityToken(issuer: null, audience: null,
            claims: claims, expires: expires, signingCredentials: credential);

            return new ResponseAuthentication() {
                token = new JwtSecurityTokenHandler().WriteToken(jwtSecurity),
                expiration = expires
            };
        }
        
    }
}