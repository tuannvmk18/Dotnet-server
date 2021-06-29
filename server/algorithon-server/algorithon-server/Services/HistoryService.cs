using System.Collections.Generic;
using System.Threading.Tasks;
using algorithon_server.Configs;
using algorithon_server.Interfaces;
using algorithon_server.Models;
using MongoDB.Driver;

namespace algorithon_server.Services
{
    public class HistoryService: IHistoryService
    {
        private readonly IMongoCollection<History> _history;
        //
        public HistoryService()
        {
            Mongodb db = new Mongodb();
            _history = db.client.GetDatabase("dotnet-algo").GetCollection<History>("history");
        }
        
        public async Task<List<History>> Get()
        {
            return _history.Find(FilterDefinition<History>.Empty).ToListAsync().Result;
        }
        
        public async Task<History> Get(string id) =>
            await _history.Find<History>(history => history.Id == id).FirstOrDefaultAsync();

        public async Task<History> Create(History history)
        {
            await _history.InsertOneAsync(history);
            return history;
        }
    }
}