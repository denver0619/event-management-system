namespace event_management_system.Domain.Entities
{
    public class Ticket : ITicket
    {
        public Ticket() { }
        public Ticket(string ticketID,
            string eventID,
            string studentID)
        {
            TicketID = ticketID;
            EventID = eventID;
            StudentID = studentID;
        }
        public Ticket(ITicket ticket)
        {
            TicketID = ticket.TicketID;
            EventID = ticket.EventID;
            StudentID = ticket.StudentID;
        }
        public string? TicketID { get; set; }
        public string? EventID { get; set; }
        public string? StudentID { get; set; }
    }
}
