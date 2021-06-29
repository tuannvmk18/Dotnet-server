using IdGen;

namespace algorithon_server.Models
{
    public class History
    {
        public string IdUser { get; set; }
        
        public string Id = new IdGenerator(0).CreateId().ToString();

        public string HistoryId
        {
            get
            {
                return this.Id;
            }
        }

        public string StartAt { get; set; }
        
        public string EndAt { get; set; }
        
        public string Program { get; set; }
        
        public string RunTime { get; set; }
        
        public Language Language { get; set; }
        
        public float Score { get; set; }
    }
}