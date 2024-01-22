using event_management_system.Domain.DataTransferObject;

namespace event_management_system.Domain.Models
{
    public class EventAttendeesModel
    {
        public List<EventAttendeeDataTransferObject>? ListAttendees { get; set; }
    }
}
