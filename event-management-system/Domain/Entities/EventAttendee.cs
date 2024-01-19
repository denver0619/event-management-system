namespace event_management_system.Domain.Entities
{
    public class EventAttendee : IEventAttendee
    {
        public EventAttendee() { }
        public EventAttendee(string eventAttendeeID,
            string eventID,
            string studentID,
            bool isApproved)
        {
            EventAttendeeID = eventAttendeeID;
            EventID = eventID;
            StudentID = studentID;
            IsApproved = isApproved;
        }
        public EventAttendee (IEventAttendee eventAttendee)
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
    }
}
