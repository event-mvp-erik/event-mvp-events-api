using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EventMvpEventsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private static readonly List<EventDto> Events = new List<EventDto>
        {
            new EventDto { Id = 1, Name = "React Conference", Date = "2025-06-01", Location = "Stockholm", Description = "A conference about React." },
            new EventDto { Id = 2, Name = "Dotnet Meetup", Date = "2025-06-15", Location = "Gothenburg", Description = "A meetup about .NET development." }
        };

        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> GetAll()
        {
            return Ok(Events);
        }

        [HttpGet("{id}")]
        public ActionResult<EventDto> GetById(int id)
        {
            var evt = Events.FirstOrDefault(e => e.Id == id);
            if (evt == null)
                return NotFound();
            return Ok(evt);
        }
    }

    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
    }
}
