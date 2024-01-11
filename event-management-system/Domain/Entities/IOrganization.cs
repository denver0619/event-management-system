namespace event_management_system.Domain.Entities
{
    public interface IOrganization
    {
        public string OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string AccreditationStatus { get; set; }
        public string OrganizationDescription { get; set; }
        public string Hash {  get; set; }
        public string Email {  get; set; }
    }
}
