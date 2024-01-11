using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Repositories
{
    public interface IStudentAffiliationRepository
    {
        public void AddStudentAffiliation(IStudentAffiliation studentAffiliation);
        public void RemoveStudentAffiliation(IStudentAffiliation studentAffiliation);
        public void UpdateStudentAffiliation(IStudentAffiliation studentAffiliation);
        public List<IStudentAffiliation> GetAllStudentAffiliations();
    }
}
