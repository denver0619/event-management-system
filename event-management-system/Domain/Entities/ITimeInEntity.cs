namespace event_management_system.Domain.Entities
{
    public interface ITimeInEntity
    {
        public string? TimeInID {  get; set; }
        public string? TicketID { get; set; }
        public DateTime? TimeIn {  get; set; }
        public bool IsIn {  get; set; }
    }
}
