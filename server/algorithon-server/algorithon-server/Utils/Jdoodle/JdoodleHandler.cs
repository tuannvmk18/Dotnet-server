using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace algorithon_server.Utils.Jdoodle
{
    public class JdoodleHandler
    {
        Data _data = new Data();

        public async Task<string> PostRunRequest(String lang,String index, String program)
        {
            HttpClient http = new HttpClient();
            var path = "https://api.jdoodle.com/execute";

            this._data.language = lang;
            this._data.versionIndex = index;
            this._data.script = program;
            this._data.clientId = "bb4cad1d63e573afaa6ffa81f65429aa";
            this._data.clientSecret = "80972fcd15a6dcd151e83133b8cddd704bb61b4f3cd9df4e80fa5f203bc1c64e";
            var json = JsonConvert.SerializeObject(this._data);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

           
            var respose = await http.PostAsync(path, data);

            if (respose.IsSuccessStatusCode)
            {
                return respose.Content.ReadAsStringAsync().Result;
            }

            return null;
        }
    }

    public class Data
    {
        public String language { get; set; }
        public String versionIndex { get; set; }
        public String script { get; set; }
        public String clientId { get; set; }
        public String clientSecret { get; set; }
    }
}