using event_management_system.Domain.DataTransferObject;
using event_management_system.Domain.Entities;
using event_management_system.Domain.Models;
using event_management_system.Domain.Repositories;

namespace event_management_system.Services
{
    public class HomeService : IDisposable
    {
        EventNatureRepository eventNatureRepository;
        EventStatusRepository eventStatusRepository;
        EventRepository eventRepository;
        OrganizationRepository organizationRepository;
        public HomeModel Model { get; set; }

        public HomeService()
        {
            eventNatureRepository = new EventNatureRepository();
            eventStatusRepository = new EventStatusRepository();
            eventRepository = new EventRepository();
            organizationRepository = new OrganizationRepository();
            Model = new HomeModel();
            Model = GetAllUpcommingEvents();
        }

        public HomeService(string organizationID)
        {
            eventNatureRepository = new EventNatureRepository();
            eventStatusRepository = new EventStatusRepository();
            eventRepository = new EventRepository();
            organizationRepository = new OrganizationRepository();
            Model = new HomeModel();
            Model = GetAllUpcommingEventsByOrganizationID(organizationID);
        }

        public HomeModel GetAllUpcommingEvents()
        {
            List<IEvent> events = eventRepository.GetUpcomingEvents().OrderByDescending(eventEntity => eventEntity.DateStart).ToList();
            List<EventDataTransferObject> eventList = new List<EventDataTransferObject>();
            foreach (IEvent eventEntity in events)
            {
                EventDataTransferObject eventDataTransferObject = new EventDataTransferObject(eventEntity);
                eventDataTransferObject.Nature = eventNatureRepository.GetByID(eventEntity.EventID!);
                eventDataTransferObject.Organization = organizationRepository.GetByID(eventEntity.OrganizationID!);
                eventDataTransferObject.Status = eventStatusRepository.GetByID(eventEntity.EventStatusID!);
                eventList.Add(eventDataTransferObject);
            }
            Model.ListEvents = eventList;
            return Model;
        }

        public HomeModel GetAllUpcommingEventsByOrganizationID(string organizationID)
        {
            List<IEvent> events =  eventRepository.GetUpcomingEventsByOrganizationID(organizationID).OrderByDescending(eventEntity => eventEntity.DateStart).ToList();
            List<EventDataTransferObject> eventList = new List<EventDataTransferObject>();
            foreach (IEvent eventEntity in events)
            {
                EventDataTransferObject eventDataTransferObject = new EventDataTransferObject(eventEntity);
                eventDataTransferObject.Nature = eventNatureRepository.GetByID(eventEntity.EventID!);
                eventDataTransferObject.Organization = organizationRepository.GetByID(eventEntity.OrganizationID!);
                eventDataTransferObject.Status = eventStatusRepository.GetByID(eventEntity.EventStatusID!);
                eventList.Add(eventDataTransferObject);
            }
            Model.ListEvents = eventList;
            return Model;
        }

        public void Dispose()
        {
            eventNatureRepository.Dispose();
            eventStatusRepository.Dispose();
            eventRepository.Dispose();
            organizationRepository.Dispose();
        }
    }
}
