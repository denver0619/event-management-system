using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Repositories
{
    public interface IEventRepository
    {
        public void AddEvent(IEvent eventEntity);
        public void RemoveEvent(IEvent eventEntity);
        public void UpdateEvent (IEvent eventEntity);
        public List<IEvent> GetAllEvents();
    }
}
