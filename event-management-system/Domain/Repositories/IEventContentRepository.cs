using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Repositories
{
    public interface IEventContentRepository
    {
        public void AddEventContent(IEventContent eventContent);
        public void EditEventContent (IEventContent eventContent);
        public void DeleteEventContent (IEventContent eventContent);
        public List<IEventContent> GetAllEventContents();
    }
}
