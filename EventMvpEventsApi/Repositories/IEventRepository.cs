using EventMvpEventsApi.Controllers;
using System.Collections.Generic;

namespace EventMvpEventsApi.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<EventDto> GetAll();
        EventDto? GetById(int id);
        EventDto Create(EventDto newEvent);
    }
}
