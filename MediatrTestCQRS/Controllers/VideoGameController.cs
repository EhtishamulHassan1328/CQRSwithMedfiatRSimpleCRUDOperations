using MediatR;
using MediatrTestCQRS.Commands;
using MediatrTestCQRS.Models;
using MediatrTestCQRS.Queries;
using MediatrTestCQRS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MediatrTestCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VideoGamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetAll()
        {
            var videoGames = await _mediator.Send(new GetAllVideoGamesQuery());
            return Ok(videoGames);
        }


        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<VideoGame>> GetByIdAsync(int id)
        {
            var videoGame = await _mediator.Send(new GetVideoGameByIdQuery(id));
            return videoGame;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateVideoGameAsync([FromBody] CreateVideoGameCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid video game data.");
            }
            var videoGameId = await _mediator.Send(command);
            return videoGameId;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGameAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid video game ID.");
            }
            await _mediator.Send(new DeleteVideoGameCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideoGameAsync(int id, [FromBody] UpdateVideoGameCommand command)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid video game data.");
            }
            var updatedId = await _mediator.Send(command);
            return Ok(updatedId);
        }
    }
}
