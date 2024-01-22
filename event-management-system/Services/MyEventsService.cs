using event_management_system.Domain.DataTransferObject;
using event_management_system.Domain.Entities;
using event_management_system.Domain.Models;
using event_management_system.Domain.Repositories;

namespace event_management_system.Services
{
    public class MyEventsService : IDisposable
    {
        EventAttendeeRepository eventAttendeeRepository;
        EventNatureRepository eventNatureRepository;
        EventStatusRepository eventStatusRepository;
        EventRepository eventRepository;
        OrganizationRepository organizationRepository;
        public MyEventsModel Model { get; set; }

        public MyEventsService()
        {
            eventAttendeeRepository = new EventAttendeeRepository();
            eventNatureRepository = new EventNatureRepository();
            eventStatusRepository = new EventStatusRepository();
            eventRepository = new EventRepository();
            organizationRepository = new OrganizationRepository();
            Model = new MyEventsModel();
        }

        public MyEventsModel GetAllMyEvents(string studentID)
        {
            List<IEventAttendee> eventsAttended = eventAttendeeRepository.GetByStudentID(studentID);
            List<EventDataTransferObject> events = new List<EventDataTransferObject>();
            foreach (IEventAttendee eventAttended in eventsAttended)
            {
                EventDataTransferObject eventEntity = new EventDataTransferObject(eventRepository.GetByID(eventAttended.EventID!));
                eventEntity.Nature = eventNatureRepository.GetByID(eventEntity.EventNatureID!);
                eventEntity.Status = eventStatusRepository.GetByID(eventEntity.EventStatusID!);
                eventEntity.Organization = organizationRepository.GetByID(eventEntity.OrganizationID!);
                events.Add(eventEntity);
            }
            Model.MyEventList = events;
            return Model;
        }

        public void Dispose()
        {
            eventAttendeeRepository.Dispose();
            eventNatureRepository.Dispose();
            organizationRepository.Dispose();
            eventStatusRepository.Dispose();
            eventRepository.Dispose();
        }

    }
}
