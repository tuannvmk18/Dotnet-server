using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using algorithon_server.Models;
using algorithon_server.Utils.Common;
using algorithon_server.Utils.Jdoodle;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace algorithon_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompilerController : ControllerBase
    {
        [HttpPost]
        public JdoodleResponse Run(JdoodleRequest body)
        {
            JdoodleData result;
            try
            {
                if (body == null || body.Index == null || body.Lang == null || body.Program == null)
                {
                    return new JdoodleResponse()
                    {
                        Error = "Body invalid",
                        Data = null,
                        Message = "Error"
                    };
                }

                var jdoodle = new JdoodleHandler();
                var jdoodleData = jdoodle.PostRunRequest(body.Lang, body.Index, body.Program);
                result = JsonConvert.DeserializeObject<JdoodleData>(jdoodleData.Result);
            }
            catch (Exception err)
            {
                return new JdoodleResponse()
                {
                    Error = err.ToString(),
                    Data = null,
                    Message = "OK"
                };
            }
            
            return new JdoodleResponse()
            {
                Error = null,
                Data = result,
                Message = "OK"
            };
        }

        [HttpPost]
        [Route("submit-challenge")]
        public List<JdoodleData> SubmitChallenge(JdoodleChallenge body)
        {
            List<JdoodleData> result = new List<JdoodleData>();

            JdoodleRequest request = new JdoodleRequest()
            {
                Index = body.Index,
                Lang = body.Lang,
                Program = body.Program
            };
            JdoodleResponse response = this.Run(request);
            result.Insert(0, response.Data);
            return result;
        }
        
    }
}