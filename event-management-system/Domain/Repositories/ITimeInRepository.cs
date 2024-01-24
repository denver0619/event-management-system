using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Repositories
{
    public interface ITimeInRepository
    {
        public void AddTimeIn (ITimeInEntity timeInEntity);
        public void UpdateTimeIn (ITimeInEntity timeInEntity);
        public List<ITimeInEntity> GetAllTimeIn ();
        public ITimeInEntity GetTimeInByID (string timeInEntityID);
        public ITimeInEntity GetTimeInByTicketID(string ticketID);
    }
}
