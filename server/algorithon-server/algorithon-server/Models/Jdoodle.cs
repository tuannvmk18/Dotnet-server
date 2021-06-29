using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace algorithon_server.Models
{
    public class JdoodleRequest
    {
        [Required]
        public String Lang { get; set; }
        
        [Required]
        public String Index { get; set; }
        
        [Required]
        public String Program {get; set; }
    }
    
    public class JdoodleResponse
    {
        [Required]
        public String Message { get; set; }
        
        [Required]
        public String Error { get; set; }
        
        [Required]
        public JdoodleData Data {get; set; }
    }

    public class TestCases
    {
        public dynamic Input { get; set; }
        public dynamic Output { get; set; }
    }

    public class JdoodleData
    {
        public string Output { get; set; }
        public string StatusCode { get; set; }
        public string Memory { get; set; }
        public string CpuTime { get; set; }
    }

    public class JdoodleChallenge : JdoodleRequest
    {
        public TestCases[] TestCase { get; set; }
    }
}