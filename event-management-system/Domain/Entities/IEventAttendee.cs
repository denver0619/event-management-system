namespace event_management_system.Domain.Entities
{
    public interface IEventAttendee
    {
        public string? EventAttendeeID { get; set; }
        public string? EventID { get; set; }
        public string? StudentID { get; set; }
        public bool IsApproved { get; set; }
    }
}
