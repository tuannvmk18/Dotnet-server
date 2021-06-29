using System.Collections.Generic;
using System.Threading.Tasks;
using algorithon_server.Models;

namespace algorithon_server.Interfaces
{
    public interface IChallengeService
    {
        Task<List<Challenge>> GetAll();

        Challenge GetById(string challenge);

        Task<Challenge> Create(Challenge challenge);

        void Update(string title, Challenge challenge);
    }
}