using event_management_system.Domain.Entities;
using event_management_system.Infrastructures;
using Microsoft.AspNetCore.DataProtection;
using System.Data;

namespace event_management_system.Domain.Repositories
{
    public class TimeInRepository : ITimeInRepository, IDisposable
    {
        private DatabaseHelper<TimeInEntity> databaseHelper;
        private string tableName = "timein";

        public TimeInRepository()
        {
            databaseHelper = new DatabaseHelper<TimeInEntity>();
        }

        public void AddTimeIn(ITimeInEntity timeInEntity)
        {
            databaseHelper.InsertRecord(tableName, new TimeInEntity(timeInEntity));
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }

        public List<ITimeInEntity> GetAllTimeIn()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<ITimeInEntity> timeInList = new List<ITimeInEntity>();
            foreach (DataRow row in dataTable.Rows)
            {
                TimeInEntity eventNature = new TimeInEntity(
                    row["TimeInID"].ToString()!,
                    row["TicketID"].ToString()!,
                    DateTime.Parse(row["TimeIn"].ToString()!),
                    bool.Parse(row["IsIn"].ToString()!)
                    );
                timeInList.Add(eventNature);
            }
            return timeInList;
        }

        public ITimeInEntity GetTimeInByID(string timeInEntityID)
        {
            string constraints = "TimeInID = " +timeInEntityID;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            if (!(dataTable.Rows.Count > 0))
            {
                return new TimeInEntity();
            }
            else
            {
                DataRow row = dataTable.Rows[0];
                return new TimeInEntity(
                    row["TimeInID"].ToString()!,
                    row["TicketID"].ToString()!,
                    DateTime.Parse(row["TimeIn"].ToString()!),
                    bool.Parse(row["IsIn"].ToString()!)
                    );
            }
        }

        public ITimeInEntity GetTimeInByTicketID(string ticketID)
        {
            string constraints = "TicketID = " + ticketID;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            if (!(dataTable.Rows.Count > 0))
            {
                return new TimeInEntity();
            }
            else
            {
                DataRow row = dataTable.Rows[0];
                return new TimeInEntity(
                    row["TimeInID"].ToString()!,
                    row["TicketID"].ToString()!,
                    DateTime.Parse(row["TimeIn"].ToString()!),
                    bool.Parse(row["IsIn"].ToString()!)
                    );
            }
        }

        public void UpdateTimeIn(ITimeInEntity timeInEntity)
        {
            databaseHelper.UpdateRecord(tableName, new TimeInEntity(timeInEntity));
        }
    }
}
