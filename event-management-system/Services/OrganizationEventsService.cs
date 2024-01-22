using event_management_system.Domain.Entities;
using event_management_system.Domain.Models;
using event_management_system.Domain.Repositories;

namespace event_management_system.Services
{
    public class OrganizationEventsService : IDisposable
    {
        EventNatureRepository eventNatureRepository;
        EventStatusRepository eventStatusRepository;
        EventRepository eventRepository;
        OrganizationRepository organizationRepository;
        public OrganizationEventsModel Model { get; set; }

        public OrganizationEventsService(string organizationID)
        {
            eventNatureRepository = new EventNatureRepository();
            eventStatusRepository = new EventStatusRepository();
            eventRepository = new EventRepository();
            organizationRepository = new OrganizationRepository();
            organizationRepository = new OrganizationRepository();
            Model = new OrganizationEventsModel();
            Model = GetAllOrganizationEvents(organizationID);
        }

        public OrganizationEventsModel GetAllOrganizationEvents(string organizationID)
        {
            List<IEvent> eventList = eventRepository.GetUpcommingEventsByOrganizationID(organizationID).OrderByDescending(eventEntity => eventEntity.DateStart!).ToList();
            Model.OrganizationEventList = eventList;
            return Model;
        }


        public void Dispose()
        {
            eventNatureRepository.Dispose();
            organizationRepository.Dispose();
            eventStatusRepository.Dispose();
            eventRepository.Dispose();
        }
    }
}
