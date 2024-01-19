namespace event_management_system.Domain.Entities
{
    public class EventContent : IEventContent
    {
        public EventContent () { }
        public EventContent (string eventContentID,
            string eventID,
            string eventContentTypeID,
            string content)
        {
            EventContentID = eventContentID;
            EventID = eventID;
            EventContentTypeID = eventContentTypeID;
            Content = content;
        }
        public EventContent (IEventContent eventContent)
        {
            EventContentID = eventContent.EventContentID;
            EventID = eventContent.EventID;
            EventContentTypeID = eventContent.EventContentTypeID;
            Content = eventContent.Content;
        }

        public string? EventContentID { get; set; }
        public string? EventID { get; set; }
        public string? EventContentTypeID { get; set; }
        public string? Content { get; set; }
    }
}
