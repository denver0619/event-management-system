namespace event_management_system.Domain.Entities
{
    public class StudentAffiliation : IStudentAffiliation
    {
        public StudentAffiliation() { }
        public StudentAffiliation(string studentAffiliationID, string studentID, string organizationID)
        {
            StudentAffiliationID = studentAffiliationID;
            StudentID = studentID;
            OrganizationID = organizationID;
        }
        public StudentAffiliation(IStudentAffiliation studentAffiliation)
        {
            StudentAffiliationID = studentAffiliation.StudentAffiliationID;
            StudentID = studentAffiliation.StudentID;
            OrganizationID = studentAffiliation.OrganizationID;
        }
    
        public string? StudentAffiliationID { get; set; }
        public string? StudentID { get; set; }
        public string? OrganizationID { get; set; }
    }
}
