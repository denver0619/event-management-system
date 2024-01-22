using event_management_system.Domain.DataTransferObject;
using event_management_system.Domain.Entities;
using event_management_system.Domain.Models;
using event_management_system.Domain.Repositories;

namespace event_management_system.Services.Events.EventManagement
{
    public class EventAttendeesService : IDisposable
    {
        private EventAttendeeRepository eventAttendeeRepository;
        private EventRepository eventRepository;
        private StudentRepository studentRepository;
        public EventAttendeesModel Model { get; set; }

        public EventAttendeesService (string eventID)
        {
            eventAttendeeRepository = new EventAttendeeRepository ();
            eventRepository = new EventRepository ();
            studentRepository = new StudentRepository ();
            Model = new EventAttendeesModel ();
            Model = GetEventAttendeesList(eventID);
        }

        public EventAttendeesModel GetEventAttendeesList(string eventID)
        {
            List<IEventAttendee> eventAttendees = eventAttendeeRepository.GetByEventID(eventID);
            List<EventAttendeeDataTransferObject> eventAttendeesData = new List<EventAttendeeDataTransferObject> ();
            foreach (IEventAttendee eventAttendee in eventAttendees)
            {
                EventAttendeeDataTransferObject eventAttendeeData = new EventAttendeeDataTransferObject(eventAttendee);
                eventAttendeeData.Student = studentRepository.GetByID(eventAttendee.StudentID!);
                eventAttendeeData.Event = eventRepository.GetByID (eventAttendee.EventID!);
                eventAttendeesData.Add(eventAttendeeData);
            }
            Model.ListAttendees = eventAttendeesData;
            return Model;
        }

        public void UpdateApproveStatus(IEventAttendee eventAttendee)
        {
            eventAttendeeRepository.UpdateEventAttendee(eventAttendee);
        }

        public void Dispose()
        {
            eventAttendeeRepository.Dispose ();
            eventRepository.Dispose ();
            studentRepository.Dispose ();
        }
    }
}
