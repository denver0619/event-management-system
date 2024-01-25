using event_management_system.Domain.DataTransferObject;
using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Models
{
    public class AttendeeManagementModel
    {
        public List<EventAttendeeDataTransferObject>? AttendeeList { get; set; }
    }
}
