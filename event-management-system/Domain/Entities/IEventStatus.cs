namespace event_management_system.Domain.Entities
{
    public interface IEventStatus
    {
        public string EventStatusID { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
    }
}
