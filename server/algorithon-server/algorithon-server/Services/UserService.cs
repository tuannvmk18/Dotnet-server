using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using algorithon_server.Configs;
using algorithon_server.Controllers;
using algorithon_server.Helpers;
using algorithon_server.Interfaces;
using algorithon_server.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;

namespace algorithon_server.Services
{
    public class UserService : IUserService
    {
        // hardcode, get from database later
        private List<User> _users = new List<User>
        {
            new User { Id = "1", FirstName = "Test", LastName = "User", UserName = "test", Password = "test", Email = "user@gmail.com" },
            new User { Id = "2", FirstName = "Test", LastName = "User", UserName = "test1", Password = "123456", Email = "123@gmail.com" }
        };

        private readonly AppSetting _appSettings;

        private IMongoCollection<User> _collection;
        // get Secret which is the secret key.
        public UserService(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
            _collection = new Mongodb().client.GetDatabase("dotnet-algo").GetCollection<User>("user");
        }
        
        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim("id", user.Id), }),
                // Token valid for 90 days.
                Expires = DateTime.UtcNow.AddDays(90),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _collection.Find(x => x.UserName == model.UserName && x.Password == model.Password).SingleOrDefaultAsync();
            
            // if user not found -> return null
            if (user == null) return null;
            // else, generateToken
            var token = generateJwtToken(user.Result);

            _collection.UpdateOneAsync(
                Builders<User>.Filter.Eq("_id", user.Result.Id), 
                Builders<User>.Update.Set("Token", token));
            return new AuthenticateResponse(user.Result, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetByToken(string token)
        {
            return _collection.Find(x => x.Token == token).FirstOrDefaultAsync().Result;
        }

        public User GetById(string id)
        {
            return _collection.Find(x => x.Id == id).FirstOrDefault();
        }


        public async Task<bool> SignUp(User user)
        {
            // check if username already exist.
            var flag = await _collection.Find(x => x.UserName == user.UserName).CountDocumentsAsync();

            if (flag > 0)
            {
                return false;
            }
            await _collection.InsertOneAsync(user);

            return true;
        }
    }
}