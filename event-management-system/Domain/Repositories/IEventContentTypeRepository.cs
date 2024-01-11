using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Repositories
{
    public interface IEventContentTypeRepository
    {
        public void AddEventContentType(IEventContentType eventContentType);
        public void UpdateEventContentType (IEventContentType eventContentType);
        public void DeleteEventContentType (IEventContentType eventContentType);
        public List<IEventContentType> GetAllEventContentTypes ();
        public IEventContentType GetByID(string id);
    }
}
