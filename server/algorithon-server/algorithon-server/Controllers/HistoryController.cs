using algorithon_server.Interfaces;
using algorithon_server.Models;
using Microsoft.AspNetCore.Mvc;

namespace algorithon_server.Controllers
{
    [ApiController]
    [Route("history")]
    public class HistoryController: ControllerBase
    {
        private IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_historyService.Get());
        }

        [HttpPost]
        public IActionResult Create(History history)
        {
            _historyService.Create(history);
            return Ok();
        }
        
    }
}