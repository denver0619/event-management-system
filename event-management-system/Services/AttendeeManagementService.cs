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
        public AttendeeManagementModel Model { get; set; }

        public AttendeeManagementService()
        {
            eventAttendeeRepository = new EventAttendeeRepository();
            ticketRepository = new TicketRepository();
            Model = new AttendeeManagementModel();
        }

       /* public AttendeeManagementModel GetAllAttendees(string eventID)
        {
            List<IEventAttendee> attendeeData = eventAttendeeRepository.GetByEventID(eventID);
            foreach (IEventAttendee data in attendeeData)
            {
                EventAttendeeDataTransferObject eventAttendeeDataTransferObject = new EventAttendeeDataTransferObject(data);
            }
        }*/
    }
}
