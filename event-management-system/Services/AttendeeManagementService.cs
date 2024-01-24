using event_management_system.Domain.DataTransferObject;
using event_management_system.Domain.Entities;
using event_management_system.Domain.Models;
using event_management_system.Domain.Repositories;
using System.Diagnostics;
using System.Text.Json;

namespace event_management_system.Services
{
    public class AttendeeManagementService : IDisposable    
    {
        private EventAttendeeRepository eventAttendeeRepository;
        private TicketRepository ticketRepository;
        private StudentRepository studentRepository;
        private TimeOutRepository timeOutRepository;
        private TimeInRepository timeInRepository;
        public AttendeeManagementModel Model { get; set; }

        public AttendeeManagementService()
        {
            timeInRepository = new TimeInRepository();
            timeOutRepository = new TimeOutRepository();
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
            List<ITimeOutEntity> timeOutEntities = new List<ITimeOutEntity>();
            List<ITimeInEntity> timeInEntities = new List<ITimeInEntity>();
            foreach(IEventAttendee attendee in attendees)
            {
                Debug.WriteLine(attendee.IsApproved);

                if (attendee.IsApproved)
                {
                    ITicket existingTickets = ticketRepository.GetByStudentIDandEventID(attendee.StudentID!, eventID);
                    Debug.WriteLine(JsonSerializer.Serialize(existingTickets));
                    if (!(existingTickets.StudentID != null))
                    {
                        Debug.WriteLine("hatdog");

                        Ticket ticket = new Ticket()
                        {
                            EventID = eventID,
                            StudentID = attendee.StudentID,
                        };
                        ticketList.Add(ticket);
                        ticketRepository.AddTicket(ticket);
                        ITicket ticketAdded = ticketRepository.GetByStudentIDandEventID(attendee.StudentID!, eventID);
                        TimeOutEntity timeOutEntity = new TimeOutEntity()
                        {
                            TimeOut = Convert.ToDateTime("1000-01-01"),
                            IsOut = false,
                            TimeOutID = "",
                            TicketID = ticketAdded.TicketID
                        };
                        TimeInEntity timeInEntity = new TimeInEntity()
                        {
                            TimeIn = Convert.ToDateTime("1000-01-01"),
                            IsIn = false,
                            TimeInID = "",
                            TicketID = ticketAdded.TicketID,
                        };
                        timeOutEntities.Add(timeOutEntity);
                        timeInEntities.Add(timeInEntity);
                    }
                }
            }
            
            for (int i = 0; i < ticketList.Count; i++)
            {
               
                timeInRepository.AddTimeIn(timeInEntities[i]);
                timeOutRepository.AddTimeOut(timeOutEntities[i]);
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
