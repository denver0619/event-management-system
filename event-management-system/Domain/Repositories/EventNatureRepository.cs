using event_management_system.Domain.Entities;
using event_management_system.Infrastructures;
using System.Data;

namespace event_management_system.Domain.Repositories
{
    public class EventNatureRepository: IEventNatureRepository, IDisposable
    {
        private DatabaseHelper<EventNature> databaseHelper;
        private readonly string tableName = "eventnature";

        public EventNatureRepository()
        {
            databaseHelper = new DatabaseHelper<EventNature>();
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }

        public void AddEventNature(IEventNature eventNature)
        {
            databaseHelper.InsertRecord(tableName, new EventNature(eventNature));
        }

        public void UpdateEventNature(IEventNature eventNature)
        {
            databaseHelper.UpdateRecord(tableName, new EventNature(eventNature));
        }

        public List<IEventNature> GetAllEventNatures()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<IEventNature> eventNatures = new List<IEventNature>();
            foreach (DataRow row in dataTable.Rows)
            {
                EventNature eventNature = new EventNature(
                    row["EventNatureID"].ToString()!,
                    row["NatureName"].ToString()!,
                    row["NatureDescription"].ToString()!
                    );
                eventNatures.Add(eventNature);
            }
            return eventNatures;
        }

        public IEventNature GetByID(string id)
        {
            string constraints = "EventNatureID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new EventNature(
                    row["EventNatureID"].ToString()!,
                    row["NatureName"].ToString()!,
                    row["NatureDescription"].ToString()!
                    );
        }

    }
}
