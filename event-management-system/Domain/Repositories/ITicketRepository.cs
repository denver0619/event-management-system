using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Repositories
{
    public interface ITicketRepository
    {
        public void AddTicket(ITicket ticket);
        public void RemoveTicket(ITicket ticket);
        public void UpdateTicket(ITicket ticket);
        public List<ITicket> GetAllTickets();
        public ITicket GetByID(string id);
        public List<ITicket> GetByEventID(string eventID);
        public List<ITicket> GetByStudentID(string studentID);
    }
}
