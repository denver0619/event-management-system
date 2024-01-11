namespace event_management_system.Domain.Entities
{
    public interface IEventContentType
    {
        public string EventContentTypeID {  get; set; }
        public string ContentTypeName { get; set; }
    }
}
