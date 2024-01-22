using event_management_system.Domain.DataTransferObject;
using event_management_system.Domain.Entities;
using event_management_system.Domain.Models;
using event_management_system.Domain.Repositories;

namespace event_management_system.Services
{
    public class EventsServices
    {
        EventNatureRepository eventNatureRepository;
        EventStatusRepository eventStatusRepository;
        EventRepository eventRepository;
        OrganizationRepository organizationRepository;
        public EventsModel Model { get; set; }

        public EventsServices()
        {
            eventNatureRepository = new EventNatureRepository();
            eventStatusRepository = new EventStatusRepository();
            eventRepository = new EventRepository();
            organizationRepository = new OrganizationRepository();
            Model = new EventsModel();
            Model = GetAllUpcommingEvents();
            Model = GetAllPreviousEvents();
        }

        public EventsServices(string organizationID)
        {
            eventNatureRepository = new EventNatureRepository();
            eventStatusRepository = new EventStatusRepository();
            eventRepository = new EventRepository();
            organizationRepository = new OrganizationRepository();
            Model = new EventsModel();
            Model = GetAllUpcommingEventsByOrganizationID(organizationID);
            Model = GetAllPreviousEventsByOrganizationID(organizationID);
        }

        public EventsModel GetAllUpcommingEvents()
        {
            List<IEvent> events = eventRepository.GetUpcommingEvents().OrderByDescending(eventEntity => eventEntity.DateStart).ToList();
            List<EventDataTransferObject> eventList = new List<EventDataTransferObject>();
            foreach (IEvent eventEntity in events)
            {
                EventDataTransferObject eventDataTransferObject = new EventDataTransferObject(eventEntity);
                eventDataTransferObject.Nature = eventNatureRepository.GetByID(eventEntity.EventID!);
                eventDataTransferObject.Organization = organizationRepository.GetByID(eventEntity.OrganizationID!);
                eventDataTransferObject.Status = eventStatusRepository.GetByID(eventEntity.EventStatusID!);
                eventList.Add(eventDataTransferObject);
            }
            Model.ListUpcommingEvents = eventList;
            return Model;
        }

        public EventsModel GetAllUpcommingEventsByOrganizationID(string organizationID)
        {
            List<IEvent> events = eventRepository.GetUpcommingEventsByOrganizationID(organizationID).OrderByDescending(eventEntity => eventEntity.DateStart).ToList();
            List<EventDataTransferObject> eventList = new List<EventDataTransferObject>();
            foreach (IEvent eventEntity in events)
            {
                EventDataTransferObject eventDataTransferObject = new EventDataTransferObject(eventEntity);
                eventDataTransferObject.Nature = eventNatureRepository.GetByID(eventEntity.EventID!);
                eventDataTransferObject.Organization = organizationRepository.GetByID(eventEntity.OrganizationID!);
                eventDataTransferObject.Status = eventStatusRepository.GetByID(eventEntity.EventStatusID!);
                eventList.Add(eventDataTransferObject);
            }
            Model.ListUpcommingEvents = eventList;
            return Model;
        }

        public EventsModel GetAllPreviousEvents()
        {
            List<IEvent> events = eventRepository.GetPreviousEvents().OrderByDescending(eventEntity => eventEntity.DateStart).ToList();
            List<EventDataTransferObject> eventList = new List<EventDataTransferObject>();
            foreach (IEvent eventEntity in events)
            {
                EventDataTransferObject eventDataTransferObject = new EventDataTransferObject(eventEntity);
                eventDataTransferObject.Nature = eventNatureRepository.GetByID(eventEntity.EventID!);
                eventDataTransferObject.Organization = organizationRepository.GetByID(eventEntity.OrganizationID!);
                eventDataTransferObject.Status = eventStatusRepository.GetByID(eventEntity.EventStatusID!);
                eventList.Add(eventDataTransferObject);
            }
            Model.ListUpcommingEvents = eventList;
            return Model;
        }

        public EventsModel GetAllPreviousEventsByOrganizationID(string organizationID)
        {
            List<IEvent> events = eventRepository.GetPreviousEventsByOrganizationID(organizationID).OrderByDescending(eventEntity => eventEntity.DateStart).ToList();
            List<EventDataTransferObject> eventList = new List<EventDataTransferObject>();
            foreach (IEvent eventEntity in events)
            {
                EventDataTransferObject eventDataTransferObject = new EventDataTransferObject(eventEntity);
                eventDataTransferObject.Nature = eventNatureRepository.GetByID(eventEntity.EventID!);
                eventDataTransferObject.Organization = organizationRepository.GetByID(eventEntity.OrganizationID!);
                eventDataTransferObject.Status = eventStatusRepository.GetByID(eventEntity.EventStatusID!);
                eventList.Add(eventDataTransferObject);
            }
            Model.ListUpcommingEvents = eventList;
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
