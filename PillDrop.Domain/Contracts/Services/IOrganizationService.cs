using PillDrop.Domain.Entities;
using System.Collections.Generic;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IOrganizationService
    {
        void SaveOrUpdate(Organization organization);
        long Save(Organization organization);
        Organization GetOrganizationById(long id);
        IList<Organization> GetOrganizations();
    }
}