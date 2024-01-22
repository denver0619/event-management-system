using event_management_system.Domain.Entities;
using event_management_system.Infrastructures;
using System.Data;
using System.Security.Policy;

namespace event_management_system.Domain.Repositories
{
    public class OrganizationRepository: IOrganizationRepository, IDisposable
    {
        private DatabaseHelper<Organization> databaseHelper;
        private readonly string tableName = "organization";

        public OrganizationRepository()
        {
            databaseHelper = new DatabaseHelper<Organization>();
        }

        public void Dispose()
        {
            if (!databaseHelper.Equals(null))
            {
                databaseHelper!.Dispose();
            }
        }

        public void AddOrganization(IOrganization organization)
        {
            databaseHelper.InsertRecord(tableName, new Organization(organization));
        }

        //RemoveOrganization NOT YET IMPLEMENTED
        public void RemoveOrganization(IOrganization organization)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrganization(IOrganization organization)
        {
            databaseHelper.UpdateRecord(tableName, new Organization(organization));
        }

        public List<IOrganization> GetAllOrganizations()
        {
            DataTable dataTable = databaseHelper.SelectAllRecord(tableName);
            List<IOrganization> organizations = new List<IOrganization>();
            foreach (DataRow row in dataTable.Rows)
            {
                Organization organization = new Organization(
                    row["OrganizationID"].ToString()!,
                    row["OrganizationName"].ToString()!,
                    row["AccreditationStatus"].ToString()!,
                    row["OrganizationDescription"].ToString()!,
                    row["Hash"].ToString()!,
                    row["Email"].ToString()!
                    );
                organizations.Add(organization);
            }
            return organizations;
        }

        public IOrganization GetByID(string id)
        {
            string constraints = "OrganizationID = " + id;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new Organization(
                    row["OrganizationID"].ToString()!,
                    row["OrganizationName"].ToString()!,
                    row["AccreditationStatus"].ToString()!,
                    row["OrganizationDescription"].ToString()!,
                    row["Hash"].ToString()!,
                    row["Email"].ToString()!
                );
        }

        public IOrganization GetByCredential(string email, string secret)
        {
            string constraints = "Email = " + email + " AND " + "Hash = " + secret;
            DataTable dataTable = databaseHelper.SelectRecord(this.tableName, constraints);
            DataRow row = dataTable.Rows[0];
            return new Organization(
                    row["OrganizationID"].ToString()!,
                    row["OrganizationName"].ToString()!,
                    row["AccreditationStatus"].ToString()!,
                    row["OrganizationDescription"].ToString()!,
                    row["Hash"].ToString()!,
                    row["Email"].ToString()!
                );
        }
    }
}
