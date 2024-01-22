using event_management_system.Domain.Entities;
using event_management_system.Infrastructures;
using System.Data;

namespace event_management_system.Domain.Repositories
{
    public class EventContentTypeRepository: IEventContentTypeRepository, IDisposable
    {
        private DatabaseHelper<EventContentType> databaseHelper;
        private readonly string tableName = "eventcontenttype";

        public EventContentTypeRepository()
        {
            databaseHelper = new DatabaseHelper<EventContentType>();
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }

        public void AddEventContentType(IEventContentType eventContentType)
        {
            databaseHelper.InsertRecord(tableName, new EventContentType(eventContentType));
        }

        public void UpdateEventContentType(IEventContentType eventContentType)
        {
            databaseHelper.UpdateRecord(tableName, new EventContentType(eventContentType));
        }

        //DeleteEventContentType NOT YET IMPLEMENTED
        public void DeleteEventContentType(IEventContentType eventContentType)
        {
            throw new NotImplementedException();
        }

        public List<IEventContentType> GetAllEventContentTypes()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<IEventContentType> eventContentTypes = new List<IEventContentType>();
            foreach (DataRow row in dataTable.Rows)
            {
                EventContentType eventContentType = new EventContentType(
                    row["EventContentTypeID"].ToString()!,
                    row["ContentTypeName"].ToString()!
                    );
                eventContentTypes.Add(eventContentType);
            }
            return eventContentTypes;
        }

        public IEventContentType GetByID(string id)
        {
            string constraints = "EventContentTypeID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new EventContentType(
                    row["EventContentTypeID"].ToString()!,
                    row["ContentTypeName"].ToString()!
                );
        }
    }
}
