namespace event_management_system.Domain.Entities
{
    public interface IEvent
    {
        public string EventID { get; set; }
        public string EventNatureID { get; set; }
        public string EventStatusID { get; set; }
        public string OrganizationID { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Venue { get; set; }
    }
}
