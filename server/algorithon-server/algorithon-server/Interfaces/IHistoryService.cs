using System.Collections.Generic;
using System.Threading.Tasks;
using algorithon_server.Models;

namespace algorithon_server.Interfaces
{
    public interface IHistoryService
    {
        Task<List<History>> Get();
        Task<History> Get(string id);
        Task<History> Create(History history);
    }
}