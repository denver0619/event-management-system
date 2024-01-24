using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Repositories
{
    public interface ITimeOutRepository
    {
        public void AddTimeOut (ITimeOutEntity timeOutEntity);
        public void UpdateTimeOut (ITimeOutEntity timeOutEntity);
        public List<ITimeOutEntity> GetAllTimeOut ();
        public ITimeOutEntity GetTimeOutByID (string timeOutEntity);
        public ITimeOutEntity GetTimeOutByTicketID(string ticketID);
    }
}
