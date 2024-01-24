using event_management_system.Domain.Entities;
using event_management_system.Infrastructures;
using System.Data;

namespace event_management_system.Domain.Repositories
{
    public class TimeOutRepository : ITimeOutRepository, IDisposable
    {
        private DatabaseHelper<TimeOutEntity> databaseHelper;
        private string tableName = "timeout";
        public TimeOutRepository()
        {
            databaseHelper = new DatabaseHelper<TimeOutEntity>();
        }

        public void AddTimeOut(ITimeOutEntity timeOutEntity)
        {
            databaseHelper.InsertRecord(tableName, new TimeOutEntity(timeOutEntity));
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }

        public List<ITimeOutEntity> GetAllTimeOut()
        {

            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<ITimeOutEntity> timeOutList = new List<ITimeOutEntity>();
            foreach (DataRow row in dataTable.Rows)
            {
                TimeOutEntity eventNature = new TimeOutEntity(
                    row["TimeOutID"].ToString()!,
                    row["TicketID"].ToString()!,
                    DateTime.Parse(row["TimeOut"].ToString()!),
                    bool.Parse(row["IsOut"].ToString()!)
                    );
                timeOutList.Add(eventNature);
            }
            return timeOutList;
        }

        public ITimeOutEntity GetTimeOutByID(string timeOutEntity)
        {

            string constraints = "TimeOutID = " + timeOutEntity;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            if (!(dataTable.Rows.Count > 0))
            {
                return new TimeOutEntity();
            }
            else
            {
                DataRow row = dataTable.Rows[0];
                return new TimeOutEntity(
                    row["TimeOutID"].ToString()!,
                    row["TicketID"].ToString()!,
                    DateTime.Parse(row["TimeOut"].ToString()!),
                    bool.Parse(row["IsOut"].ToString()!)
                    );
            }
        }

        public ITimeOutEntity GetTimeOutByTicketID(string ticketID)
        {
            string constraints = "TicketID = " + ticketID;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            if (!(dataTable.Rows.Count > 0))
            {
                return new TimeOutEntity();

            }
            else
            {
                DataRow row = dataTable.Rows[0];
                return new TimeOutEntity(
                    row["TimeOutID"].ToString()!,
                    row["TicketID"].ToString()!,
                    DateTime.Parse(row["TimeOut"].ToString()!),
                    bool.Parse(row["IsOut"].ToString()!)
                    );
            }
        }

        public void UpdateTimeOut(ITimeOutEntity timeOutEntity)
        {
            databaseHelper.UpdateRecord(tableName, new TimeOutEntity(timeOutEntity));
        }
    }
}
