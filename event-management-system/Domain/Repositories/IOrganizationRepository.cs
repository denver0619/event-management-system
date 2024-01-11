using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Repositories
{
    public interface IOrganizationRepository
    {
        public void AddOrganization(IOrganization organization);
        public void RemoveOrganization(IOrganization organization);
        public void UpdateOrganization(IOrganization organization);
        public List<IOrganization> GetAllOrganizations();
    }
}
