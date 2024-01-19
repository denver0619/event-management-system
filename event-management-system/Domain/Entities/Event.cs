namespace event_management_system.Domain.Entities
{
    public class Event : IEvent
    {
        public Event() { }
        public Event(string eventID, 
            string eventNatureID, 
            string eventStatusID, 
            string organizationID, 
            DateTime datePosted,
            DateTime dateStart,
            DateTime dateEnd,
            string venue)
        {
            EventID = eventID;
            EventNatureID = eventNatureID;
            EventStatusID = eventStatusID;
            OrganizationID = organizationID;
            DatePosted = datePosted;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Venue = venue;
        }

        Event(IEvent eventEntity)
        {
            EventID = eventEntity.EventID;
            EventNatureID = eventEntity.EventNatureID;
            EventStatusID = eventEntity.EventStatusID;
            OrganizationID = eventEntity.OrganizationID;
            DatePosted = eventEntity.DatePosted;
            DateStart = eventEntity.DateStart;
            DateEnd = eventEntity.DateEnd;
            Venue = eventEntity.Venue;
        }

        public string? EventID { get; set; }
        public string? EventNatureID { get; set; }
        public string? EventStatusID { get; set; }
        public string? OrganizationID { get; set; }
        public DateTime? DatePosted { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string? Venue { get; set; }
    }
}
