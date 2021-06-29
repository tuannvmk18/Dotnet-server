using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using IdGen;
using MongoDB.Bson;

namespace algorithon_server.Models
{
    public class User
    {
        public string Id = new IdGenerator(0).CreateId().ToString();
        
        public string UserName { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Token { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }
    }
}