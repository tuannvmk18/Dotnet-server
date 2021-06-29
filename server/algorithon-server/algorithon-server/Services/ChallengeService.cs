using System.Collections.Generic;
using System.Threading.Tasks;
using algorithon_server.Configs;
using algorithon_server.Interfaces;
using algorithon_server.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace algorithon_server.Services
{
    public class ChallengeService : IChallengeService
    {
        
        private readonly IMongoCollection<Challenge> _challenge;
        //
        public ChallengeService()
        {
            Mongodb db = new Mongodb();
            _challenge = db.client.GetDatabase("dotnet-algo").GetCollection<Challenge>("challenge");
        }
        
        public async Task<List<Challenge>> GetAll()
        {
            return _challenge.Find(challenge => true).ToListAsync().Result;
        }
        
        public Challenge GetById(string id) =>
             _challenge.Find<Challenge>(challenge => challenge.Id == id).FirstOrDefaultAsync().Result;
        
        public async Task<Challenge> Create(Challenge challenge)
        {
            await _challenge.InsertOneAsync(challenge);
            return challenge;
        }
        
        public async void Update(string id, Challenge challengeIn) =>
          await _challenge.ReplaceOneAsync(challenge => challenge.Id == id, challengeIn);
        public async void Remove(Challenge challengeIn) => 
            await  _challenge.DeleteOneAsync(challenge => challenge.Id == challengeIn.Id);
        
        public async void Remove(string id) => 
            await _challenge.DeleteOneAsync(challenge => challenge.Id == id);
    }
}