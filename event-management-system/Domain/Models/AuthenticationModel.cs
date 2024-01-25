using event_management_system.Domain.Entities;

namespace event_management_system.Domain.Models
{
    public class AuthenticationModel
    {
        public bool IsAuthenticated { get; set; }
        public IStudent? Student { get; set; }  
        public IOrganization? Organization { get; set; }
    }
}
