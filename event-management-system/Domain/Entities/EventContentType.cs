namespace event_management_system.Domain.Entities
{
    public class EventContentType : IEventContentType
    {
        public EventContentType () { }
        public EventContentType (string eventContentTypeID,
            string contentTypeName)
        {
            EventContentTypeID = eventContentTypeID;
            ContentTypeName = contentTypeName;
        }
        public EventContentType (IEventContentType eventContentType)
        {
            EventContentTypeID = eventContentType.EventContentTypeID;
            ContentTypeName = eventContentType.ContentTypeName;
        }

        public string? EventContentTypeID { get; set; }
        public string? ContentTypeName { get; set; }
    }
}
