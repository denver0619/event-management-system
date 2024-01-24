namespace event_management_system.Domain.Entities
{
    public class TimeOutEntity : ITimeOutEntity
    {

        public TimeOutEntity() { }
        public TimeOutEntity(string? timeOutID, string? ticketID, DateTime? timeOut, bool isOut)
        {
            TimeOutID = timeOutID;
            TicketID = ticketID;
            TimeOut = timeOut;
            IsOut = isOut;
        }

        public TimeOutEntity(ITimeOutEntity timeIn)
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
    }
}
