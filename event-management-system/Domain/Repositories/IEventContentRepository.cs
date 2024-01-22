using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Repositories
{
    public interface IEventContentRepository
    {
        public void AddEventContent(IEventContent eventContent);
        public void EditEventContent (IEventContent eventContent);
        public void DeleteEventContent (IEventContent eventContent);
        public List<IEventContent> GetAllEventContents();
        public IEventContent GetByID(string id);
        public List<IEventContent> GetByEventID(string eventID);
        public List<IEventContent> GetByEventContentTypeID (string eventContentTypeID);
    }
}
