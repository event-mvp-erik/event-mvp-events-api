using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using EventMvpEventsApi.Controllers;

namespace EventMvpEventsApi.Repositories
{
    public class FileBasedEventRepository : IEventRepository
    {
        private readonly string _filePath = "events.json";
        private List<EventDto> _events;

        public FileBasedEventRepository()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                _events = JsonSerializer.Deserialize<List<EventDto>>(json) ?? new List<EventDto>();
            }
            else
            {
                _events = new List<EventDto>();
                SaveToFile();
            }
        }

        public IEnumerable<EventDto> GetAll() => _events;

        public EventDto? GetById(int id) => _events.FirstOrDefault(e => e.Id == id);

        public EventDto Create(EventDto newEvent)
        {
            newEvent.Id = _events.Any() ? _events.Max(e => e.Id) + 1 : 1;
            _events.Add(newEvent);
            SaveToFile();
            return newEvent;
        }

        private void SaveToFile()
        {
            var json = JsonSerializer.Serialize(_events, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
