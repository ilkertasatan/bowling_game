using BowlingGame.Service;
using BowlingGame.Service.Abstractions;
using BowlingGame.Web.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BowlingGame.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;

        public GameController()
        {
            this._service = new GameService();
        }

        [HttpPost]
        [Route("new")]
        public IActionResult StartNewGame()
        {
            this._service.StartNewGame();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost]
        [Route("pins/add")]
        public ActionResult AddRoll([FromBody]AddRollModel model)
        {
            this._service.AddRoll(model.Pins);
            return Ok();
        }

        [HttpGet]
        [Route("scores/total")]
        public ActionResult<int> GetTotalScore()
        {
            return Ok(_service.GetTotalScore());
        }

        [HttpGet]
        [Route("scores/{frameIndex}/total")]
        public ActionResult<int> GetFrameScore(int frameIndex)
        {
            return this._service.GetFrameScoreByIndex(frameIndex);
        }
    }
}