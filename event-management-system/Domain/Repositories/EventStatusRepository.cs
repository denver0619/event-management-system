using event_management_system.Domain.Entities;
using event_management_system.Infrastructures;
using System.Data;

namespace event_management_system.Domain.Repositories
{
    public class EventStatusRepository : IEventStatusRepository, IDisposable
    {
        private DatabaseHelper<EventStatus> databaseHelper;
        private readonly string tableName = "eventstatus";

        public EventStatusRepository()
        {
            databaseHelper = new DatabaseHelper<EventStatus>();
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }

        public void AddEventStatus(IEventStatus eventStatus)
        {
            databaseHelper.InsertRecord(tableName, new EventStatus(eventStatus));
        }

        //DeleteEventStatus NOT YET IMPLEMENTED
        public void DeleteEventStatus(IEventStatus eventStatus)
        {
            throw new NotImplementedException();
        }

        public void UpdateEventStatus(IEventStatus eventStatus)
        {
            databaseHelper.UpdateRecord(tableName, new EventStatus(eventStatus));
        }

        public List<IEventStatus> GetAllEventStatuses()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<IEventStatus> eventStatuses = new List<IEventStatus>();
            foreach (DataRow row in dataTable.Rows)
            {
                EventStatus eventStatus = new EventStatus(
                    row["EventStatusID"].ToString()!,
                    row["StatusName"].ToString()!,
                    row["StatusDescription"].ToString()!
                    );
                eventStatuses.Add(eventStatus);
            }
            return eventStatuses;
        }

        public IEventStatus GetByID(string id)
        {
            string constraints = "EventStatusID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);

            if (!(dataTable.Rows.Count > 0))
            {
                return new EventStatus();
            }
            else
            {
                DataRow row = dataTable.Rows[0];
                return new EventStatus(
                        row["EventStatusID"].ToString()!,
                        row["StatusName"].ToString()!,
                        row["StatusDescription"].ToString()!
                    );
            }
        }
       
    }
}
