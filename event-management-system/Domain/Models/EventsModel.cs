using event_management_system.Domain.DataTransferObject;
using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Models
{
    public class EventsModel
    {
        public List<EventDataTransferObject>? ListUpcomingEvents { get; set; }
        public List<EventDataTransferObject>? ListPreviousEvents { get; set; }
        public EventDataTransferObject? EventInfo { get; set; }
    }
}
