using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using CoreSight2.Data.Entities;
using CoreSight2.Helpers;
using CoreSight2.Models;
using Microsoft.Extensions.Configuration;

namespace CoreSight2.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetById(int id);
        IEnumerable<User> GetAll();
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _config;

        public UserService(IOptions<AppSettings> appSettings, IConfiguration config)
        {
            _appSettings = appSettings.Value;
            _config = config;
          }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            //var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);
            var user = new User();
            string name = _config.GetSection("User:UserName").Value;
            string password = _config.GetSection("User:Password").Value;
            user.Username = model.Username;
            user.Password = model.Password;
            user.LastName = "Donovan";
            user.Id = 54;
            user.FirstName = "Robert";

            // return null if user not found
            if (user == null) return null;
            else
            {
                if(user.Username == name && user.Password == password)
                {
                    // authentication successful so generate jwt token
                    var token = generateJwtToken(user);
                    return new AuthenticateResponse(user, token);
                }
                return null;
            }



            
        }


        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User GetById(int id)
        {
            List<User> _users = new List<User>
                {
                    new User { Id = 54, FirstName = null, LastName = null, Username = null, Password = null }
                };

            return _users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            List<User> _users = new List<User>
                {
                    new User { Id = 1, FirstName = null, LastName = null, Username = null, Password = null }
                };
            return _users;
        }
    }
}