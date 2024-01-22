using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Repositories
{
    public interface IStudentRepository
    {
        public void AddStudent(IStudent student);
        public void UpdateStudent(IStudent student);
        public void RemoveStudent(IStudent student);
        public List<IStudent> GetAllStudents();
        public IStudent GetByID(string id);
    }
}
