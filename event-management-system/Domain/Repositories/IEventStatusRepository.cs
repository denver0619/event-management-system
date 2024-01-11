using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Repositories
{
    public interface IEventStatusRepository
    {
        public void AddEventStatus(IEventStatus eventStatus);
        public void UpdateEventStatus(IEventStatus eventStatus);
        public void DeleteEventStatus(IEventStatus eventStatus);
        public List<IEventStatus> GetAllEventStatuses();
    }
}
