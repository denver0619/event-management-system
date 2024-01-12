namespace event_management_system.Domain.Entities
{
    public interface IStudent
    {
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string OrganizationID { get; set; }
        public string Hash { get; set; }
        public string Email { get; set; }
        public string YearLevel { get; set; }
        public string Contact { get; set; }
    }
}
