namespace event_management_system.Domain.Entities
{
    public class TimeInEntity : ITimeInEntity
    {
        public TimeInEntity() { }
        public TimeInEntity(string? timeInID, string? ticketID, DateTime? timeIn, bool isIn)
        {
            TimeInID = timeInID;
            TicketID = ticketID;
            TimeIn = timeIn;
            IsIn = isIn;
        }

        public TimeInEntity(ITimeInEntity timeIn)
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
    }
}
