namespace event_management_system.Domain.Entities
{
    public interface IEvent
    {
        public string? EventID { get; set; }
        public string? EventNatureID { get; set; }
        public string? EventStatusID { get; set; }
        public string? OrganizationID { get; set; }
        public DateTime? DatePosted { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string? Venue { get; set; }
        public byte[]? Image { get; set; }
        public string? Title { get; set; }
        public int ParticipantNumber { get; set; }   
        public string? EventType { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactNumber { get; set; }
        public string? FeedbackLink { get; set; }
        public string? PaymentLink { get; set; }
        public string? Description { get; set; }
    }
}
