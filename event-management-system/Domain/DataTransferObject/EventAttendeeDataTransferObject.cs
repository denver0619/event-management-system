using event_management_system.Domain.Entities;

namespace event_management_system.Domain.DataTransferObject
{
    public class EventAttendeeDataTransferObject : IEventAttendee
    {
        public EventAttendeeDataTransferObject() { }

        public EventAttendeeDataTransferObject(string eventAttendeeID,
            string eventID,
            string studentID,
            bool isApproved)
        {
            EventAttendeeID = eventAttendeeID;
            EventID = eventID;
            StudentID = studentID;
            IsApproved = isApproved;
        }
        public EventAttendeeDataTransferObject(IEventAttendee eventAttendee)
        {
            EventAttendeeID = eventAttendee.EventAttendeeID;
            EventID = eventAttendee.EventID;
            StudentID = eventAttendee.StudentID;
            IsApproved = eventAttendee.IsApproved;
        }

        public string? EventAttendeeID { get; set; }
        public string? EventID { get; set; }
        public string? StudentID { get; set; }
        public bool IsApproved { get; set; }

        public IEvent? Event { get; set; }
        public IStudent? Student { get; set; }
    }
    
}
