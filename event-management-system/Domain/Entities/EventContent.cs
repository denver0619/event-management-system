namespace event_management_system.Domain.Entities
{
    public class EventContent : IEventContent
    {
        public EventContent () { }
        public EventContent (string eventContentID,
            string eventID,
            string eventTypeID,
            string content)
        {
            EventContentID = eventContentID;
            EventID = eventID;
            EventTypeID = eventTypeID;
            Content = content;
        }
        public EventContent (IEventContent eventContent)
        {
            EventContentID = eventContent.EventContentID;
            EventID = eventContent.EventID;
            EventTypeID = eventContent.EventTypeID;
            Content = eventContent.Content;
        }

        public string? EventContentID { get; set; }
        public string? EventID { get; set; }
        public string? EventTypeID { get; set; }
        public string? Content { get; set; }
    }
}
