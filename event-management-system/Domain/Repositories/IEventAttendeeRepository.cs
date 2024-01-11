using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Repositories
{
    public interface IEventAttendeeRepository
    {
        public void AddEventAttendee(IEventAttendee eventAttendee);
        public void RemoveEventAttendee(IEventAttendee eventAttendee);
        public List<IEventAttendee> GetAllAttendees();
        public IEventAttendee GetByID(string id);
    }
}
