using System.Collections.Generic;
using IdGen;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace algorithon_server.Models
{
    public class Challenge
    {
        [BsonId]
        public string Id = new IdGenerator(0).CreateId().ToString();

        public string ChallengeId
        {
            get
            {
                return this.Id;
            }
        }
        public string Title { get; set; }
        
        public string ư { get; set; }
        
        public List<string> History { get; set; }
        
        public List<TestCase> TestCases { get; set; }
    }
}