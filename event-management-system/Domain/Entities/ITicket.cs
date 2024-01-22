namespace event_management_system.Domain.Entities
{
    public interface ITicket
    {
        public string? TicketID { get; set; }
        public string? EventID { get; set; }
        public string? StudentID { get; set; }
    }
}
