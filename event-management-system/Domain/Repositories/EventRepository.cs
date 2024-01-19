using event_management_system.Domain.Entities;
using event_management_system.Infrastructures;
using Microsoft.Extensions.Logging;
using System.Data;

namespace event_management_system.Domain.Repositories
{
    public class EventRepository: IEventRepository, IDisposable
    {
        private DatabaseHelper<Event> databaseHelper;
        private readonly string tableName = "event";

        public EventRepository()
        {
            databaseHelper = new DatabaseHelper<Event>();
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }

        public void AddEvent(IEvent eventEntity)
        {
            databaseHelper.InsertRecord(tableName, new Event(eventEntity));
        }

        //RemoveEvent NOT IMPLEMENTED YET
        public void RemoveEvent(IEvent eventEntity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEvent(IEvent eventEntity)
        {
            databaseHelper.UpdateRecord(tableName, new Event(eventEntity));
        }

        public List<IEvent> GetAllEvents()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<IEvent> eventsEntity = new List<IEvent>();
            foreach (DataRow row in dataTable.Rows)
            {
                Event eventEntity = new Event(
                    row["EventID"].ToString()!,
                    row["EventNatureID"].ToString()!,
                    row["EventStatusID,"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    DateTime.Parse(row["DatePosted"].ToString()!),
                    DateTime.Parse(row["DateStart"].ToString()!),
                    DateTime.Parse(row["DateEnd"].ToString()!),
                    row["Venue"].ToString()!
                    );
                eventsEntity.Add(eventEntity);
            }
            return eventsEntity;
        }

        public IEvent GetByID(string id)
        {
            string constraints = "EventID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new Event(
                 row["EventID"].ToString()!,
                    row["EventNatureID"].ToString()!,
                    row["EventStatusID,"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    DateTime.Parse(row["DatePosted"].ToString()!),
                    DateTime.Parse(row["DateStart"].ToString()!),
                    DateTime.Parse(row["DateEnd"].ToString()!),
                    row["Venue"].ToString()!
                    );
        }

        public List<IEvent> GetByOrganizationID(string organizationID)
        {
            string constraints = "OrganizationID = " + organizationID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(this.tableName, constraints);
            List<IEvent> eventsEntity = new List<IEvent>();
            foreach (DataRow row in dataTable.Rows)
            {
                Event eventEntity = new Event(
                    row["EventID"].ToString()!,
                    row["EventNatureID"].ToString()!,
                    row["EventStatusID,"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    DateTime.Parse(row["DatePosted"].ToString()!),
                    DateTime.Parse(row["DateStart"].ToString()!),
                    DateTime.Parse(row["DateEnd"].ToString()!),
                    row["Venue"].ToString()!
                    );
                eventsEntity.Add(eventEntity);
            }
            return eventsEntity;
        }

        public List<IEvent> GetByStatusID(string statusID)
        {
            string constraints = "EventStatusID = " + statusID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(this.tableName, constraints);
            List<IEvent> eventsEntity = new List<IEvent>();
            foreach (DataRow row in dataTable.Rows)
            {
                Event eventEntity = new Event(
                    row["EventID"].ToString()!,
                    row["EventNatureID"].ToString()!,
                    row["EventStatusID,"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    DateTime.Parse(row["DatePosted"].ToString()!),
                    DateTime.Parse(row["DateStart"].ToString()!),
                    DateTime.Parse(row["DateEnd"].ToString()!),
                    row["Venue"].ToString()!
                    );
                eventsEntity.Add(eventEntity);
            }
            return eventsEntity;
        }

        public List<IEvent> GetByNatureID(string natureID)
        {
            string constraints = "EventNatureID = " + natureID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(this.tableName, constraints);
            List<IEvent> eventsEntity = new List<IEvent>();
            foreach (DataRow row in dataTable.Rows)
            {
                Event eventEntity = new Event(
                    row["EventID"].ToString()!,
                    row["EventNatureID"].ToString()!,
                    row["EventStatusID,"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    DateTime.Parse(row["DatePosted"].ToString()!),
                    DateTime.Parse(row["DateStart"].ToString()!),
                    DateTime.Parse(row["DateEnd"].ToString()!),
                    row["Venue"].ToString()!
                    );
                eventsEntity.Add(eventEntity);
            }
            return eventsEntity;
        }

      
    }




}
