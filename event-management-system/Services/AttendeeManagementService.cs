using event_management_system.Domain.DataTransferObject;
using event_management_system.Domain.Entities;
using event_management_system.Domain.Models;
using event_management_system.Domain.Repositories;

namespace event_management_system.Services
{
    public class AttendeeManagementService
    {
        private EventAttendeeRepository eventAttendeeRepository;
        private TicketRepository ticketRepository;
        private StudentRepository studentRepository;
        public AttendeeManagementModel Model { get; set; }

        public AttendeeManagementService()
        {
            eventAttendeeRepository = new EventAttendeeRepository();
            ticketRepository = new TicketRepository();
            studentRepository = new StudentRepository();
            Model = new AttendeeManagementModel();
        }

        public AttendeeManagementModel GetAllAttendees(string eventID)
        {
            List<IEventAttendee> attendeeData = eventAttendeeRepository.GetByEventID(eventID);
            List<EventAttendeeDataTransferObject> attendeeList = new List<EventAttendeeDataTransferObject>();
            foreach (IEventAttendee data in attendeeData)
            {
                EventAttendeeDataTransferObject eventAttendeeDataTransferObject = new EventAttendeeDataTransferObject(data);
                eventAttendeeDataTransferObject.Student = studentRepository.GetByID(data.StudentID!);
                attendeeList
            }

        }
    }
}
