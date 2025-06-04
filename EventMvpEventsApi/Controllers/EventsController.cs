using EventMvpEventsApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EventMvpEventsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _repository;

        public EventsController(IEventRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<EventDto> GetById(int id)
        {
            var evt = _repository.GetById(id);
            if (evt == null)
                return NotFound();
            return Ok(evt);
        }

        [HttpPost]
        public ActionResult<EventDto> Create([FromBody] EventDto newEvent)
        {
            if (string.IsNullOrWhiteSpace(newEvent.Title) || string.IsNullOrWhiteSpace(newEvent.Date))
                return BadRequest("Title and Date are required.");

            var created = _repository.Create(newEvent);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }

    public class EventDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
