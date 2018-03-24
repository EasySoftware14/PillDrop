
using System.Collections.Generic;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Repositories
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        IList<Organization> GetOrganizations();
        Organization GetOrganizationById(long id);
    }
}