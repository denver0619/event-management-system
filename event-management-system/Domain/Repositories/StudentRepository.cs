using event_management_system.Domain.Entities;
using event_management_system.Infrastructures;
using System.Data;

namespace event_management_system.Domain.Repositories
{
    public class StudentRepository: IStudentRepository, IDisposable
    {
        private DatabaseHelper<Student> databaseHelper;
        private readonly string tableName = "student";

        public StudentRepository()
        {
            databaseHelper = new DatabaseHelper<Student>();
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }

        public void AddStudent(IStudent student)
        {
            databaseHelper.InsertRecord(tableName, new Student(student));
        }

        public void UpdateStudent(IStudent student)
        {
            databaseHelper.UpdateRecord(tableName, new Student(student));
        }

        //RemoveStudent NOT YET IMPLEMENTED
        public void RemoveStudent(IStudent student)
        {
            throw new NotImplementedException();
        }

        public List<IStudent> GetAllStudents()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<IStudent> students = new List<IStudent>();
            foreach (DataRow row in dataTable.Rows)
            {
                Student student = new Student(
                    row["StudentID"].ToString()!,
                    row["FirstName"].ToString()!,
                    row["MiddleName"].ToString()!,
                    row["LastName"].ToString()!,
                    row["Suffix"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    row["Hash"].ToString()!,
                    row["Email"].ToString()!,
                    row["YearLevel"].ToString()!,
                    row["Contact"].ToString()!
                    );
                students.Add(student);
            }
            return students;
        }

        public IStudent GetByID(string id)
        {
            string constraints = "StudentID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new Student(
                    row["StudentID"].ToString()!,
                    row["FirstName"].ToString()!,
                    row["MiddleName"].ToString()!,
                    row["LastName"].ToString()!,
                    row["Suffix"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    row["Hash"].ToString()!,
                    row["Email"].ToString()!,
                    row["YearLevel"].ToString()!,
                    row["Contact"].ToString()!
                );
        }
        public IStudent GetByCredential(string email, string secret)
        {
            string constraints = "Email = " + email + " AND " + "Hash = " + secret; 
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new Student(
                    row["StudentID"].ToString()!,
                    row["FirstName"].ToString()!,
                    row["MiddleName"].ToString()!,
                    row["LastName"].ToString()!,
                    row["Suffix"].ToString()!,
                    row["OrganizationID"].ToString()!,
                    row["Hash"].ToString()!,
                    row["Email"].ToString()!,
                    row["YearLevel"].ToString()!,
                    row["Contact"].ToString()!
                );
        }
    }
}
