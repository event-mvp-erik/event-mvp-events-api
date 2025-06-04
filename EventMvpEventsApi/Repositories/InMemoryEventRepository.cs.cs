using System.Collections.Generic;
using System.Linq;
using EventMvpEventsApi.Controllers;
using EventMvpEventsApi.Repositories;

namespace EventMvpEventsApi.Repositories
{
    public class InMemoryEventRepository : IEventRepository
    {
        private readonly List<EventDto> _events = new List<EventDto>
        {
            new EventDto { Id = 1, Title = "React Conference", Date = "2025-06-01", Location = "Stockholm", Description = "A conference about React and frontend tech." },
            new EventDto { Id = 2, Title = "Dotnet Meetup", Date = "2025-06-15", Location = "Gothenburg", Description = "A meetup for .NET developers in Sweden." }
        };

        public IEnumerable<EventDto> GetAll() => _events;

        public EventDto? GetById(int id) => _events.FirstOrDefault(e => e.Id == id);

        public EventDto Create(EventDto newEvent)
        {
            newEvent.Id = _events.Max(e => e.Id) + 1;
            _events.Add(newEvent);
            return newEvent;
        }
    }
}
