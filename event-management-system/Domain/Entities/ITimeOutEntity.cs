namespace event_management_system.Domain.Entities
{
    public interface ITimeOutEntity
    {
        public string? TimeOutID { get; set; }
        public string? TicketID { get; set; }
        public DateTime? TimeOut { get; set; }
        public bool IsOut { get; set; }
    }
}
