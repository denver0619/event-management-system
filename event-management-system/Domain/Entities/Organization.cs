namespace event_management_system.Domain.Entities
{
    public class Organization : IOrganization
    {
        public Organization() { }
        public Organization(string organizationID,
            string organizationName,
            string accreditationStatus,
            string organizationDescription,
            string hash,
            string email)
        {
            OrganizationID = organizationID;
            OrganizationName = organizationName;
            AccreditationStatus = accreditationStatus;
            OrganizationDescription = organizationDescription;
            Hash = hash;
            Email = email;
        }
        public Organization(IOrganization organization)
        {
            OrganizationID = organization.OrganizationID;
            OrganizationName = organization.OrganizationName;
            AccreditationStatus = organization.AccreditationStatus;
            OrganizationDescription = organization.OrganizationDescription;
            Hash = organization.Hash;
            Email = organization.Email;
        }
        public string? OrganizationID { get; set; }
        public string? OrganizationName { get; set; }
        public string? AccreditationStatus { get; set; }
        public string? OrganizationDescription { get; set; }
        public string? Hash { get; set; }
        public string? Email { get; set; }
    }
}
