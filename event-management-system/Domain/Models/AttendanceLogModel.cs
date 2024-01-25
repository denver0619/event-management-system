using event_management_system.Domain.DataTransferObject;

namespace event_management_system.Domain.Models
{
    public class AttendanceLogModel
    {
        public List<TimeInDataTransferObject>? TimeInList { get; set; }
        public List<TimeOutDataTransferObject>? TimeOutList { get; set;}
    }
}
