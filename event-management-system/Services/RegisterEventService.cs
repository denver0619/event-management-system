using event_management_system.Domain.Entities;
using event_management_system.Domain.Models;
using event_management_system.Domain.Repositories;

namespace event_management_system.Services
{
    public class RegisterEventService : IDisposable
    {
        private EventAttendeeRepository eventAttendeeRepository;

        public RegisterEventModel Model { get; set; }

        public RegisterEventService ()
        {
            eventAttendeeRepository = new EventAttendeeRepository ();
            Model = new RegisterEventModel ();
        }

        public void AddEventAttendee(IEventAttendee eventAttendee)
        {
            eventAttendeeRepository.AddEventAttendee (eventAttendee);
        }

        public void Dispose ()
        {
            eventAttendeeRepository.Dispose();
        }
     }
}
