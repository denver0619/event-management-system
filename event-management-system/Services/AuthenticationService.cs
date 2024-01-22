using event_management_system.Domain.Entities;
using event_management_system.Domain.Models;
using event_management_system.Domain.Repositories;

namespace event_management_system.Services
{
    public class AuthenticationService : IDisposable
    {
        OrganizationRepository organizationRepository;
        StudentRepository studentRepository;

        public AuthenticationModel Model { get; set; }

        public AuthenticationService()
        {
            organizationRepository = new OrganizationRepository();
            studentRepository = new StudentRepository();
            Model = new AuthenticationModel();
        }

        public void AuthenticateStudent(string email, string secret)
        {
            IStudent student = studentRepository.GetByCredential("'" + email + "'", secret);
            if(string.IsNullOrEmpty(student.StudentID))
            {
                Model.IsAuthenticated = false;
            }
            else
            {
                Model.IsAuthenticated = true;
                Model.Student = studentRepository.GetByID(student.StudentID);
            }
        }


        public void AuthenticateOrganization(string email, string secret)
        {
            IOrganization organization = organizationRepository.GetByCredential("'" + email + "'", secret);
            if (string.IsNullOrEmpty(organization.OrganizationID))
            {
                Model.IsAuthenticated = false;
            }
            else
            {
                Model.IsAuthenticated = true;
                Model.Organization = organizationRepository.GetByID(organization.OrganizationID);
            }
        }

        public void Dispose()
        {
            studentRepository.Dispose();
            studentRepository.Dispose();
        }

    }
}
