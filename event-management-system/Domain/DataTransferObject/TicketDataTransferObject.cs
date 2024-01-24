using event_management_system.Domain.Entities;

namespace event_management_system.Domain.DataTransferObject
{
    public class TicketDataTransferObject : ITicket
    {
        public TicketDataTransferObject() { }
        public TicketDataTransferObject(string ticketID,
            string eventID,
            string studentID)
        {
            TicketID = ticketID;
            EventID = eventID;
            StudentID = studentID;
        }
        public TicketDataTransferObject(ITicket ticket)
        {
            TicketID = ticket.TicketID;
            EventID = ticket.EventID;
            StudentID = ticket.StudentID;
        }
        public string? TicketID { get; set; }
        public string? EventID { get; set; }
        public string? StudentID { get; set; }
        public Student? Student { get; set; }
    }
}

