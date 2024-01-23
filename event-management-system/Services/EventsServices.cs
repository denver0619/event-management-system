using event_management_system.Domain.DataTransferObject;
using event_management_system.Domain.Entities;
using event_management_system.Domain.Models;
using event_management_system.Domain.Repositories;
using System.Diagnostics;
using System.Text.Json;

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
            Model = GetAllUpcomingEvents();
            Model = GetAllPreviousEvents();
        }

        public EventsServices(string organizationID)
        {
            eventNatureRepository = new EventNatureRepository();
            eventStatusRepository = new EventStatusRepository();
            eventRepository = new EventRepository();
            organizationRepository = new OrganizationRepository();
            Model = new EventsModel();
            Model = GetAllUpcomingEventsByOrganizationID(organizationID);
            Model = GetAllPreviousEventsByOrganizationID(organizationID);
        }

        public EventsModel GetAllUpcomingEvents()
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
            Model.ListUpcomingEvents = eventList;          
            return Model;
        }

        public EventsModel GetAllUpcomingEventsByOrganizationID(string organizationID)
        {
            List<IEvent> events = eventRepository.GetUpcomingEventsByOrganizationID(organizationID).OrderByDescending(eventEntity => eventEntity.DateStart).ToList();
            List<EventDataTransferObject> eventList = new List<EventDataTransferObject>();
            foreach (IEvent eventEntity in events)
            {
                EventDataTransferObject eventDataTransferObject = new EventDataTransferObject(eventEntity);
                eventDataTransferObject.Nature = eventNatureRepository.GetByID(eventEntity.EventID!);
                eventDataTransferObject.Organization = organizationRepository.GetByID(eventEntity.OrganizationID!);
                eventDataTransferObject.Status = eventStatusRepository.GetByID(eventEntity.EventStatusID!);
                eventList.Add(eventDataTransferObject);
            }
            Model.ListUpcomingEvents = eventList;
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
            Model.ListUpcomingEvents = eventList;
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
            Model.ListUpcomingEvents = eventList;
            return Model;
        }

        public EventsModel GetEventInfoById(string eventID)
        {
            IEvent eventEntity = eventRepository.GetByID(eventID);
            EventDataTransferObject eventData = new EventDataTransferObject(eventEntity);
            eventData.Organization = organizationRepository.GetByID(eventEntity.OrganizationID!);
            eventData.Nature = eventNatureRepository.GetByID(eventEntity.EventNatureID!);
            eventData.Status = eventStatusRepository.GetByID(eventEntity.EventStatusID!);
            Model.EventInfo = eventData;
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
