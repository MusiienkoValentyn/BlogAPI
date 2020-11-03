using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace BLL.Services
{
    public class JWTService : IJWT
    {
        private readonly IConfiguration _configuration;
        IUnitOfWork UnitOfWork { get; set; }

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JWTService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public string Login(UserDTO user)
        {
            var login = UnitOfWork.User.GetAll().FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);

            if (login == null)
            {
                return String.Empty;              
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType,login.UserName)
                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            var date = DateTime.UtcNow;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"])); //
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtIssuer"],
                audience: _configuration["JwtAudience"],
                notBefore: date,
                claims: claimsIdentity.Claims,
                expires: expiry,
                signingCredentials: creds
            );

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodedToken;
        }
    }
}
