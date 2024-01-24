using event_management_system.Domain.Entities;

namespace event_management_system.Domain.DataTransferObject
{
    public class TimeOutDataTransferObject : ITimeOutEntity
    {


        public TimeOutDataTransferObject() { }
        public TimeOutDataTransferObject(string? timeOutID, string? ticketID, DateTime? timeOut, bool isOut)
        {
            TimeOutID = timeOutID;
            TicketID = ticketID;
            TimeOut = timeOut;
            IsOut = isOut;
        }

        public TimeOutDataTransferObject(ITimeOutEntity timeIn)
        {
            TimeOutID = timeIn.TimeOutID;
            TicketID = timeIn.TicketID;
            TimeOut = timeIn.TimeOut;
            IsOut = timeIn.IsOut;
        }
        public string? TimeOutID { get; set; }
        public string? TicketID { get; set; }
        public DateTime? TimeOut { get; set; }
        public bool IsOut { get; set; }

        public ITicket? Ticket { get; set; }
        public IStudent? Student { get; set; }
    }
}
