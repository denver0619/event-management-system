namespace event_management_system.Domain.Entities
{
    public interface IStudentAffiliation
    {
        public string StudentAffiliationID { get; set; }
        public string StudentID { get; set; }
        public string OrganizationID { get; set; }
    }
}
