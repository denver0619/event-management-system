using event_management_system.Domain.Entities;
using event_management_system.Infrastructures;
using System.Data;

namespace event_management_system.Domain.Repositories
{
    public class EventContentRepository : IEventContentRepository, IDisposable
    {
        private DatabaseHelper<EventContent> databaseHelper;
        private readonly string tableName = "eventcontents";

        public EventContentRepository()
        {
            databaseHelper = new DatabaseHelper<EventContent>();
        }
        public void AddEventContent(IEventContent eventContent)
        {
            databaseHelper.InsertRecord(tableName, new EventContent( eventContent));
        }

        public void DeleteEventContent(IEventContent eventContent)
        {
            string constraints = "EventContentID = " + eventContent.EventContentID;
            databaseHelper.DeleteRecord(tableName, constraints);
        }

        public void EditEventContent(IEventContent eventContent)
        {
            databaseHelper.UpdateRecord(tableName, new EventContent( eventContent));
        }

        public List<IEventContent> GetAllEventContents()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<IEventContent> eventContents = new List<IEventContent>(); 
            foreach (DataRow row in dataTable.Rows)
            {
                EventContent eventContent = new EventContent(
                    row["EventContentID"].ToString()!,
                    row["EventID"].ToString()!,
                    row["EventTypeID"].ToString()!,
                    row["Content"].ToString()!);
                eventContents.Add(eventContent);
            }
            return eventContents;
        }

        public List<IEventContent> GetByEventID(string eventID)
        {
            string constraints = "EventID = " + eventID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List<IEventContent> eventContents = new List<IEventContent>();
            foreach (DataRow row in dataTable.Rows)
            {
                EventContent eventContent = new EventContent(
                    row["EventContentID"].ToString()!,
                    row["EventID"].ToString()!,
                    row["EventTypeID"].ToString()!,
                    row["Content"].ToString()!);
                eventContents.Add(eventContent);
            }
            return eventContents;
        }

        public List<IEventContent> GetByEventContentTypeID(string eventContentTypeID)
        {
            string constraints = "EventContentTypeID = " + eventContentTypeID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List<IEventContent> eventContents = new List<IEventContent>();
            foreach (DataRow row in dataTable.Rows)
            {
                EventContent eventContent = new EventContent(
                    row["EventContentID"].ToString()!,
                    row["EventID"].ToString()!,
                    row["EventTypeID"].ToString()!,
                    row["Content"].ToString()!);
                eventContents.Add(eventContent);
            }
            return eventContents;
        }

        public IEventContent GetByID(string eventContentID)
        {
            string constraints = "EventContentID = " + eventContentID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName,constraints);
            DataRow row = dataTable.Rows[0];
            return new EventContent(
                    row["EventContentID"].ToString()!,
                    row["EventID"].ToString()!,
                    row["EventTypeID"].ToString()!,
                    row["Content"].ToString()!);
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }
    }
}
