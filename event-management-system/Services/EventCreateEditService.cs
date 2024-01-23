using event_management_system.Domain.Entities;
using event_management_system.Domain.Models;
using event_management_system.Domain.Repositories;

namespace event_management_system.Services
{
    public class EventCreateEditService : IDisposable
    {
        EventRepository eventRepository;
        public EventCreateEditModel Model { get; set; }

        public EventCreateEditService()
        {
            eventRepository = new EventRepository();
            Model = new EventCreateEditModel();
        }

        public EventCreateEditService(string eventID)
        {
            eventRepository = new EventRepository();
            Model = new EventCreateEditModel();
        }

        public void AddEvent(IEvent eventEntity)
        {
            eventRepository.AddEvent(eventEntity);
        }

        public EventCreateEditModel GetEventData(string eventID)
        {
            IEvent eventEntity = eventRepository.GetByID(eventID);
            Model.Event = eventEntity;
            return Model;
        }
        public void UpdateEvent(IEvent eventEntity)
        {
            eventRepository.UpdateEvent(eventEntity);
        }

        public void Dispose()
        {
            eventRepository.Dispose();
        }
    }
}
