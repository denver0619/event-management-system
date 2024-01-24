using event_management_system.Domain.Entities;
using event_management_system.Infrastructures;
using System.Data;

namespace event_management_system.Domain.Repositories
{
    public class EventAttendeeRepository: IEventAttendeeRepository, IDisposable
    {
        private DatabaseHelper<EventAttendee> databaseHelper;
        private readonly string tableName = "eventattendees";

        public EventAttendeeRepository()
        {
            databaseHelper = new DatabaseHelper<EventAttendee>();
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }

        public void AddEventAttendee(IEventAttendee eventAttendee)
        {
            databaseHelper.InsertRecord(tableName, new EventAttendee(eventAttendee));
        }

        public void UpdateEventAttendee(IEventAttendee eventAttendee)
        {
            string constraints = "EventAttendeeID = " + eventAttendee.EventAttendeeID;
            databaseHelper.UpdateRecordWithConstraint(tableName, new EventAttendee(eventAttendee), constraints);
        }

        public List<IEventAttendee> GetAllAttendees()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<IEventAttendee> eventAttendees = new List<IEventAttendee>();
            foreach (DataRow row in dataTable.Rows)
            {
                EventAttendee eventAttendee = new EventAttendee(
                    row["EventAttendeeID"].ToString()!,
                    row["EventID"].ToString()!,
                    row["StudentID"].ToString()!,
                    bool.Parse(row["IsApproved"].ToString()!)
                    );
                    eventAttendees.Add( eventAttendee ); 
            }
            return eventAttendees;
        }

        public IEventAttendee GetByID(string id)
        {
            string constraints = "EventAttendeesID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new EventAttendee(
                    row["EventAttendeeID"].ToString()!,
                    row["EventID"].ToString()!,
                    row["StudentID"].ToString()!,
                    bool.Parse(row["IsApproved"].ToString()!)
                );
        }
        public List<IEventAttendee> GetByEventID(string eventID)
        {
            string constraints = "EventID = " + eventID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(this.tableName, constraints);
            List<IEventAttendee> eventAttendees = new List<IEventAttendee>();
            foreach (DataRow row in dataTable.Rows)
            {
                EventAttendee eventAttendee = new EventAttendee(
                    row["EventAttendeeID"].ToString()!,
                    row["EventID"].ToString()!,
                    row["StudentID"].ToString()!,
                    bool.Parse(row["IsApproved"].ToString()!)
                    );
                eventAttendees.Add(eventAttendee);
            }
            return eventAttendees;
        }

        public List<IEventAttendee> GetByStudentID(string studentID)
        {
            string constraints = "StudentID = " + studentID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(this.tableName, constraints);
            List<IEventAttendee> eventAttendees = new List<IEventAttendee>();
            foreach (DataRow row in dataTable.Rows)
            {
                EventAttendee eventAttendee = new EventAttendee(
                    row["EventAttendeeID"].ToString()!,
                    row["EventID"].ToString()!,
                    row["StudentID"].ToString()!,
                    bool.Parse(row["IsApproved"].ToString()!)
                    );
                eventAttendees.Add(eventAttendee);
            }
            return eventAttendees;
        }
    }
}
