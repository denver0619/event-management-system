namespace event_management_system.Domain.Entities
{
    public class EventStatus : IEventStatus
    {
        public EventStatus() { }
        public EventStatus(string eventStatusID,
            string statusName,
            string statusDescription)
        {
            EventStatusID = eventStatusID;
            StatusName = statusName;
            StatusDescription = statusDescription;
        }
        public EventStatus(IEventStatus eventStatus)
        {
            EventStatusID = eventStatus.EventStatusID;
            StatusName = eventStatus.StatusName;
            StatusDescription = eventStatus.StatusDescription;
        }
        public string? EventStatusID { get; set; }
        public string? StatusName { get; set; }
        public string? StatusDescription { get; set; }
    }
}
