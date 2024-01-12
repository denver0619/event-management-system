namespace event_management_system.Domain.Entities
{
    public interface IEventContent
    {
        public string EventContentID { get; set; }
        public string EventID { get; set; }
        public string EventTypeID { get; set; }
        public string Content { get; set; }
    }
}
