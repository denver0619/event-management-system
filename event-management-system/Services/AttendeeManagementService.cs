using event_management_system.Domain.DataTransferObject;
using event_management_system.Domain.Entities;
using event_management_system.Domain.Models;
using event_management_system.Domain.Repositories;

namespace event_management_system.Services
{
    public class AttendeeManagementService : IDisposable    
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
                attendeeList.Add(eventAttendeeDataTransferObject);
            }
            Model.AttendeeList = attendeeList;
            return Model;
        }

        public void UpdateStudentApproveStatus(IEventAttendee eventAttendee)
        {
            eventAttendeeRepository.UpdateEventAttendee(eventAttendee);
        }

        public void GenerateTickets(string eventID)
        {
            List<IEventAttendee> attendees = eventAttendeeRepository.GetByEventID(eventID);
            List<ITicket> ticketList = new List<ITicket>(); 
            foreach(IEventAttendee attendee in attendees)
            {
                if (attendee.IsApproved)
                {
                    ITicket existingTickets = ticketRepository.GetByStudentIDandEventID(attendee.StudentID!, eventID);
                    if(existingTickets.StudentID != null && existingTickets.StudentID == attendee.StudentID)
                    {
                        Ticket ticket = new Ticket()
                        {
                            EventID = eventID,
                            StudentID = attendee.StudentID,
                        };
                        ticketList.Add(ticket);
                    }
                }
            }
            foreach (ITicket ticket in ticketList)
            {
                ticketRepository.AddTicket(ticket);
            }
        }

        public void Dispose()
        {
            ticketRepository.Dispose();
            studentRepository.Dispose();
            eventAttendeeRepository.Dispose();
        }

    }
}
