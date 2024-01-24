using event_management_system.Domain.Entities;
using event_management_system.Infrastructures;
using Microsoft.Extensions.Logging;
using System.Data;

namespace event_management_system.Domain.Repositories
{
    public class StudentAffiliationRepository: IStudentAffiliationRepository, IDisposable
    {
        private DatabaseHelper<StudentAffiliation> databaseHelper;
        private readonly string tableName = "studentaffiliation";

        public StudentAffiliationRepository()
        {
            databaseHelper = new DatabaseHelper<StudentAffiliation>();
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }

        public void AddStudentAffiliation(IStudentAffiliation studentAffiliation)
        {
            databaseHelper.InsertRecord(tableName, new StudentAffiliation(studentAffiliation));
        }

        //RemoveStudentAffiliation NOT YET IMPLEMENTED
        public void RemoveStudentAffiliation(IStudentAffiliation studentAffiliation)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudentAffiliation(IStudentAffiliation studentAffiliation)
        {
            databaseHelper.UpdateRecord(tableName, new StudentAffiliation(studentAffiliation));
        }

        public List<IStudentAffiliation> GetAllStudentAffiliations()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<IStudentAffiliation> studentAffiliations = new List<IStudentAffiliation>();
            foreach (DataRow row in dataTable.Rows)
            {
                StudentAffiliation studentAffiliation = new StudentAffiliation(
                    row["StudentAffiliationID"].ToString()!,
                    row["StudentID"].ToString()!,
                    row["OrganizationID"].ToString()!
                    );
                studentAffiliations.Add(studentAffiliation);
            }
            return studentAffiliations;
        }

        public IStudentAffiliation GetByID(string id)
        {
            string constraints = "StudentAffiliationID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new StudentAffiliation(
                    row["StudentAffiliationID"].ToString()!,
                    row["StudentID"].ToString()!,
                    row["OrganizationID"].ToString()!
                    );
        }

        public List<IStudentAffiliation> GetByStudentID(string studentID)
        {
            string constraints = "StudentID = " + studentID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(this.tableName, constraints);
            List<IStudentAffiliation> studentAffiliations = new List<IStudentAffiliation>();
            foreach (DataRow row in dataTable.Rows)
            {
                StudentAffiliation studentAffiliation = new StudentAffiliation(
                    row["StudentAffiliationID"].ToString()!,
                    row["StudentID"].ToString()!,
                    row["OrganizationID"].ToString()!
                    );
                studentAffiliations.Add(studentAffiliation);
            }
            return studentAffiliations;
        }

        public List<IStudentAffiliation> GetByOrganizationID(string organizationID)
        {
            string constraints = "OrganizationID = " + organizationID;
            DataTable dataTable = databaseHelper.SelectAllRecordWith(this.tableName, constraints);
            List<IStudentAffiliation> studentAffiliations = new List<IStudentAffiliation>();
            foreach (DataRow row in dataTable.Rows)
            {
                StudentAffiliation studentAffiliation = new StudentAffiliation(
                    row["StudentAffiliationID"].ToString()!,
                    row["StudentID"].ToString()!,
                    row["OrganizationID"].ToString()!
                    );
                studentAffiliations.Add(studentAffiliation);
            }
            return studentAffiliations;
        }
    }
}
