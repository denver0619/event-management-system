using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Repositories
{
    public interface IEventNatureRepository
    {
        public void AddEventNature(IEventNature eventNature);
        public void RemoveEventNature(IEventNature eventNature);
        public void UpdateEventNature (IEventNature eventNature);
        public List<IEventNature> GetAllEventNatures();
        public IEventNature GetByID(string id);
    }
}
