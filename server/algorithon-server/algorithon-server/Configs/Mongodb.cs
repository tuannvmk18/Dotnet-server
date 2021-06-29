using MongoDB.Driver;

namespace algorithon_server.Configs
{
    public class Mongodb
    {
        private string name { set; get; }
        private string password { set; get; }
        public MongoClient client { set; get; }
        public Mongodb()
        {
            this.client = new MongoClient($"mongodb+srv://Admin:01664983385TUan@iot.jvz5x.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
        }
    }
}