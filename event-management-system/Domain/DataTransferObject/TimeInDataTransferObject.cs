using event_management_system.Domain.Entities;

namespace event_management_system.Domain.DataTransferObject
{
    public class TimeInDataTransferObject : ITimeInEntity
    {

        public TimeInDataTransferObject() { }
        public TimeInDataTransferObject(string? timeInID, string? ticketID, DateTime? timeIn, bool isIn)
        {
            TimeInID = timeInID;
            TicketID = ticketID;
            TimeIn = timeIn;
            IsIn = isIn;
        }

        public TimeInDataTransferObject(ITimeInEntity timeIn)
        {
            TimeInID = timeIn.TimeInID;
            TicketID = timeIn.TicketID;
            TimeIn = timeIn.TimeIn;
            IsIn = timeIn.IsIn;
        }

        public string? TimeInID { get; set; }
        public string? TicketID { get; set; }
        public DateTime? TimeIn { get; set; }
        public bool IsIn {  get; set; }

        public ITicket? Ticket { get; set; }
        public IStudent? Student { get; set; }
    }

}
