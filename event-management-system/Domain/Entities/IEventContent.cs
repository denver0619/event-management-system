namespace event_management_system.Domain.Entities
{
    public interface IEventContent
    {
        public string? EventContentID { get; set; }
        public string? EventID { get; set; }
        public string? EventContentTypeID { get; set; }
        public string? Content { get; set; }
    }
}
