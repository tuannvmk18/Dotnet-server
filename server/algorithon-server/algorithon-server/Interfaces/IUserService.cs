using System.Collections.Generic;
using System.Threading.Tasks;
using algorithon_server.Controllers;
using algorithon_server.Models;

namespace algorithon_server.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetByToken(string token);
        User GetById(string id);
        Task<bool> SignUp(User user);
    }
}