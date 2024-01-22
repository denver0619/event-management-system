namespace event_management_system.Domain.Entities
{
    public class Student : IStudent
    {
        public Student() { }
        public Student(string studentID,
            string firstName,
            string middleName,
            string lastName,
            string suffix,
            string organizationID,
            string hash,
            string email,
            string yearLevel,
            string contact)
        {
            StudentID = studentID;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Suffix = suffix;
            OrganizationID = organizationID;
            Hash = hash;
            Email = email;
            YearLevel = yearLevel;
            Contact = contact;
        }

        public Student(IStudent student)
        {
            StudentID = student.StudentID;
            FirstName = student.FirstName;
            MiddleName = student.MiddleName;
            LastName = student.LastName;
            Suffix = student.Suffix;
            OrganizationID = student.OrganizationID;
            Hash = student.Hash;
            Email = student.Email;
            YearLevel = student.YearLevel;
            Contact = student.Contact;
        }

        public string? StudentID { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Suffix { get; set; }
        public string? OrganizationID { get; set; }
        public string? Hash { get; set; }
        public string? Email { get; set; }
        public string? YearLevel { get; set; }
        public string? Contact { get; set; }
    }
}
