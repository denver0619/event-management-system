using event_management_system.Domain.Entities;
using event_management_system.Infrastructures;
using Microsoft.Extensions.Logging;
using System.Data;

namespace event_management_system.Domain.Repositories
{
    public class TicketRepository : ITicketRepository, IDisposable
    {
        private DatabaseHelper<Ticket> databaseHelper;
        private readonly string tableName = "ticket";

        public TicketRepository()
        {
            databaseHelper = new DatabaseHelper<Ticket>();
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }

        public void AddTicket(ITicket ticket)
        {
            databaseHelper.InsertRecord(tableName, new Ticket(ticket));
        }

        //RemoveTicket NOT YET IMPLEMENTED
        public void RemoveTicket(ITicket ticket)
        {
            throw new NotImplementedException();
        }

        public void UpdateTicket(ITicket ticket)
        {
            databaseHelper.UpdateRecord(tableName, new Ticket(ticket));
        }

        public List<ITicket> GetAllTickets()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<ITicket> tickets = new List<ITicket>();
            foreach (DataRow row in dataTable.Rows)
            {
                Ticket ticket = new Ticket(
                    row["TicketID"].ToString()!,
                    row["EventID"].ToString()!,
                    row["StudentID"].ToString()!
                    );
                tickets.Add(ticket);
            }
            return tickets;
        }

        public ITicket GetByID(string id)
        {
            string constraints = "TicketID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new Ticket(
                 row["TicketID"].ToString()!,
                    row["EventID"].ToString()!,
                    row["StudentID"].ToString()!
                );
        }

        public List<ITicket> GetByEventID(string eventID)
        {
            string constraints = "EventID = " + eventID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(this.tableName, constraints);
            List<ITicket> tickets = new List<ITicket>();
            foreach (DataRow row in dataTable.Rows)
            {
                Ticket ticket = new Ticket(
                    row["TicketID"].ToString()!,
                    row["EventID"].ToString()!,
                    row["StudentID"].ToString()!
                    );
                tickets.Add(ticket);
            }
            return tickets;
        }

        public List<ITicket> GetByStudentID(string studentID)
        {
            string constraints = "StudentID = " + studentID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(this.tableName, constraints);
            List<ITicket> tickets = new List<ITicket>();
            foreach (DataRow row in dataTable.Rows)
            {
                Ticket ticket = new Ticket(
                    row["TicketID"].ToString()!,
                    row["EventID"].ToString()!,
                    row["StudentID"].ToString()!
                    );
                tickets.Add(ticket);
            }
            return tickets;
        }
    }
    
}
