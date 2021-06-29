using algorithon_server.Interfaces;
using algorithon_server.Models;
using Microsoft.AspNetCore.Mvc;

namespace algorithon_server.Controllers
{
    [ApiController]
    [Route("challenge")]
    public class ChallengeController : ControllerBase
    {
        private IChallengeService _challengeService;

        public ChallengeController(IChallengeService challengeService)
        {
            _challengeService = challengeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_challengeService.GetAll());
        }
        
        [HttpGet("{challengeId}")]
        public IActionResult GetById(string challengeid)
        {
            return Ok(_challengeService.GetById(challengeid));
        }

        [HttpPost]
        public IActionResult Create(Challenge challenge)
        {
            _challengeService.Create(challenge);
            return Ok();
        }
        
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Challenge challengeIn)
        {
            var challenge = _challengeService.GetById(id);
        
            if (challenge == null)
            {
                return NotFound();
            }
        
            _challengeService.Update(id, challengeIn);
        
            return NoContent();
        }
    }
}