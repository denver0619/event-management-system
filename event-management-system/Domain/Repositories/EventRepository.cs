using event_management_system.Domain.Entities;
using event_management_system.Infrastructures;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace event_management_system.Domain.Repositories
{
    public class EventRepository: IEventRepository, IDisposable
    {
        private DatabaseHelper<Event> databaseHelper;
        private readonly string tableName = "events";

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
            Event eventData = new Event(eventEntity);
            Debug.WriteLine(JsonSerializer.Serialize(eventData));
            /*MySqlParameter parameter =  new MySqlParameter("@Image", MySqlDbType.Blob, ((eventData.Image != null && !(eventData.Image!.Length>0))?eventData.Image.Length:0));*/
            string query = "INSERT INTO events (ContactNumber,ContactPerson,DateEnd,DatePosted,DateStart,Description,EventType,FeedbackLink,Image,OrganizationID,ParticipantNumber,PaymentLink,Title,Venue, EventNatureID, EventStatusID) Values " +
                "("+"\'"+eventData.ContactNumber + "\',\'" + eventData.ContactPerson + "\',\'" + 
                string.Join(" ", new List<string> { ((DateTime)eventData.DateEnd!).ToString("yyyy-MM-dd hh:mm:ss "), ((DateTime)eventData.DateEnd!).ToString("tt").ToUpper()}) + "\',\'" +
                string.Join(" ", new List<string> { ((DateTime)eventData.DatePosted!).ToString("yyyy-MM-dd hh:mm:ss "), ((DateTime)eventData.DatePosted!).ToString("tt").ToUpper() }) + "\',\'" +
                string.Join(" ", new List<string> { ((DateTime)eventData.DateStart!).ToString("yyyy-MM-dd hh:mm:ss "), ((DateTime)eventData.DateStart!).ToString("tt").ToUpper() }) + "\',\'" + 
                eventData.Description + "\',\'" + eventData.EventType + "\',\'" + eventData.FeedbackLink + "\',\'" + eventData.Image + "\'," + eventData.OrganizationID + "," +
                eventData.ParticipantNumber + ",\'" + eventData.PaymentLink + "\',\'" + eventData.Title + "\',\'" + eventData.Venue + "\'," + eventData.EventNatureID + "," + eventData.EventStatusID+");";
            databaseHelper.InsertRecordEvent(query);
        }

        //RemoveEvent NOT IMPLEMENTED YET
        public void RemoveEvent(IEvent eventEntity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEvent(IEvent eventEntity)
        {
            Event eventData = new Event(eventEntity);
            string constraint = "EventID = " + eventData.EventID;
            // MySqlParameter parameter = new MySqlParameter("@Image", MySqlDbType.Blob, ((eventData.Image != null && !(eventData.Image!.Length > 0)) ? eventData.Image.Length : 0));
            databaseHelper.UpdateRecordWithConstraint(tableName, eventData, constraint);
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
                    row["EventStatusID"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    DateTime.Parse(row["DatePosted"].ToString()!),
                    DateTime.Parse(row["DateStart"].ToString()!),
                    DateTime.Parse(row["DateEnd"].ToString()!),
                    row["Venue"].ToString()!,
                    row["Image"].ToString()!,
                    row["Title"].ToString()!,
                    Int32.Parse(row["ParticipantNumber"].ToString()!),
                    row["EventType"].ToString()!,
                    row["ContactPerson"].ToString()!,
                    row["ContactNumber"].ToString()!,
                    row["FeedbackLink"].ToString()!,
                    row["PaymentLink"].ToString()!,
                    row["Description"].ToString()!
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
                    row["EventStatusID"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    DateTime.Parse(row["DatePosted"].ToString()!),
                    DateTime.Parse(row["DateStart"].ToString()!),
                    DateTime.Parse(row["DateEnd"].ToString()!),
                    row["Venue"].ToString()!,
                    row["Image"].ToString()!,
                    row["Title"].ToString()!,
                    Int32.Parse(row["ParticipantNumber"].ToString()!),
                    row["EventType"].ToString()!,
                    row["ContactPerson"].ToString()!,
                    row["ContactNumber"].ToString()!,
                    row["FeedbackLink"].ToString()!,
                    row["PaymentLink"].ToString()!,
                    row["Description"].ToString()!
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
                    row["EventStatusID"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    DateTime.Parse(row["DatePosted"].ToString()!),
                    DateTime.Parse(row["DateStart"].ToString()!),
                    DateTime.Parse(row["DateEnd"].ToString()!),
                    row["Venue"].ToString()!,
                    row["Image"].ToString()!,
                    row["Title"].ToString()!,
                    Int32.Parse(row["ParticipantNumber"].ToString()!),
                    row["EventType"].ToString()!,
                    row["ContactPerson"].ToString()!,
                    row["ContactNumber"].ToString()!,
                    row["FeedbackLink"].ToString()!,
                    row["PaymentLink"].ToString()!,
                    row["Description"].ToString()!
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
                    row["EventStatusID"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    DateTime.Parse(row["DatePosted"].ToString()!),
                    DateTime.Parse(row["DateStart"].ToString()!),
                    DateTime.Parse(row["DateEnd"].ToString()!),
                    row["Venue"].ToString()!,
                    row["Image"].ToString()!,
                    row["Title"].ToString()!,
                    Int32.Parse(row["ParticipantNumber"].ToString()!),
                    row["EventType"].ToString()!,
                    row["ContactPerson"].ToString()!,
                    row["ContactNumber"].ToString()!,
                    row["FeedbackLink"].ToString()!,
                    row["PaymentLink"].ToString()!,
                    row["Description"].ToString()!
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
                    row["EventStatusID"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    DateTime.Parse(row["DatePosted"].ToString()!),
                    DateTime.Parse(row["DateStart"].ToString()!),
                    DateTime.Parse(row["DateEnd"].ToString()!),
                    row["Venue"].ToString()!,
                    row["Image"].ToString()!,
                    row["Title"].ToString()!,
                    Int32.Parse(row["ParticipantNumber"].ToString()!),
                    row["EventType"].ToString()!,
                    row["ContactPerson"].ToString()!,
                    row["ContactNumber"].ToString()!,
                    row["FeedbackLink"].ToString()!,
                    row["PaymentLink"].ToString()!,
                    row["Description"].ToString()!
                    );
                eventsEntity.Add(eventEntity);
            }
            return eventsEntity;
        }

        public List<IEvent> GetUpcomingEvents ()
        {
            DateTime date = DateTime.Now;
            string constraints = "DateStart > " + "\'" + date.ToString("yyyy-MM-dd hh:mm:ss ") + date.ToString("tt").ToUpper() + "\'";
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List<IEvent> eventsEntity = new List<IEvent>();
            foreach (DataRow row in dataTable.Rows)
            {
                Event eventEntity = new Event(
                    row["EventID"].ToString()!,
                    row["EventNatureID"].ToString()!,
                    row["EventStatusID"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    DateTime.Parse(row["DatePosted"].ToString()!),
                    DateTime.Parse(row["DateStart"].ToString()!),
                    DateTime.Parse(row["DateEnd"].ToString()!),
                    row["Venue"].ToString()!,
                    row["Image"].ToString()!,
                    row["Title"].ToString()!,
                    Int32.Parse(row["ParticipantNumber"].ToString()!),
                    row["EventType"].ToString()!,
                    row["ContactPerson"].ToString()!,
                    row["ContactNumber"].ToString()!,
                    row["FeedbackLink"].ToString()!,
                    row["PaymentLink"].ToString()!,
                    row["Description"].ToString()!
                    );
                eventsEntity.Add(eventEntity);
            }
            return eventsEntity;
        }

        public List<IEvent> GetUpcomingEventsByOrganizationID(string organizationID)
        {
            DateTime date = DateTime.Now;
            string constraints = "DateStart > " + "\'" + date.ToString("yyyy-MM-dd hh:mm:ss ") + date.ToString("tt").ToUpper() + "\'" + " AND " + "OrganizationID = " + organizationID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List<IEvent> eventsEntity = new List<IEvent>();
            foreach (DataRow row in dataTable.Rows)
            {
                Event eventEntity = new Event(
                    row["EventID"].ToString()!,
                    row["EventNatureID"].ToString()!,
                    row["EventStatusID"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    DateTime.Parse(row["DatePosted"].ToString()!),
                    DateTime.Parse(row["DateStart"].ToString()!),
                    DateTime.Parse(row["DateEnd"].ToString()!),
                    row["Venue"].ToString()!,
                    row["Image"].ToString()!,
                    row["Title"].ToString()!,
                    Int32.Parse(row["ParticipantNumber"].ToString()!),
                    row["EventType"].ToString()!,
                    row["ContactPerson"].ToString()!,
                    row["ContactNumber"].ToString()!,
                    row["FeedbackLink"].ToString()!,
                    row["PaymentLink"].ToString()!,
                    row["Description"].ToString()!
                    );
                eventsEntity.Add(eventEntity);
            }
            return eventsEntity;
        }

        public List<IEvent> GetPreviousEvents()
        {
            DateTime date = DateTime.Now;
            string constraints = "DateStart < " + "\'" + date.ToString("yyyy-MM-dd hh:mm:ss ") + date.ToString("tt").ToUpper() + "\'";
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List<IEvent> eventsEntity = new List<IEvent>();
            foreach (DataRow row in dataTable.Rows)
            {
                Event eventEntity = new Event(
                    row["EventID"].ToString()!,
                    row["EventNatureID"].ToString()!,
                    row["EventStatusID"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    DateTime.Parse(row["DatePosted"].ToString()!),
                    DateTime.Parse(row["DateStart"].ToString()!),
                    DateTime.Parse(row["DateEnd"].ToString()!),
                    row["Venue"].ToString()!,
                    row["Image"].ToString()!,
                    row["Title"].ToString()!,
                    Int32.Parse(row["ParticipantNumber"].ToString()!),
                    row["EventType"].ToString()!,
                    row["ContactPerson"].ToString()!,
                    row["ContactNumber"].ToString()!,
                    row["FeedbackLink"].ToString()!,
                    row["PaymentLink"].ToString()!,
                    row["Description"].ToString()!
                    );
                eventsEntity.Add(eventEntity);
            }
            return eventsEntity;
        }

        public List<IEvent> GetPreviousEventsByOrganizationID(string organizationID)
        {
            DateTime date = DateTime.Now;
            string constraints = "DateStart < " + "\'" + date.ToString("yyyy-MM-dd hh:mm:ss ") + date.ToString("tt").ToUpper() + "\'" + " AND " + "OrganizationID = " + organizationID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(tableName, constraints);
            List<IEvent> eventsEntity = new List<IEvent>();
            foreach (DataRow row in dataTable.Rows)
            {
                Event eventEntity = new Event(
                    row["EventID"].ToString()!,
                    row["EventNatureID"].ToString()!,
                    row["EventStatusID"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    DateTime.Parse(row["DatePosted"].ToString()!),
                    DateTime.Parse(row["DateStart"].ToString()!),
                    DateTime.Parse(row["DateEnd"].ToString()!),
                    row["Venue"].ToString()!,
                    row["Image"].ToString()!,
                    row["Title"].ToString()!,
                    Int32.Parse(row["ParticipantNumber"].ToString()!),
                    row["EventType"].ToString()!,
                    row["ContactPerson"].ToString()!,
                    row["ContactNumber"].ToString()!,
                    row["FeedbackLink"].ToString()!,
                    row["PaymentLink"].ToString()!,
                    row["Description"].ToString()!
                    );
                eventsEntity.Add(eventEntity);
            }
            return eventsEntity;
        }
    }
}
