using System.Collections.Generic;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public Organization GetOrganizationById(long id)
        {
            return _organizationRepository.Get(id);
        }

        public IList<Organization> GetOrganizations()
        {
            return _organizationRepository.GetOrganizations();
        }
        public void SaveOrUpdate(Organization organization)
        {
            using (var trans = _organizationRepository.Session.BeginTransaction())
            {
                _organizationRepository.SaveOrUpdate(organization);
                trans.Commit();
            }
        }

        public long Save(Organization organization)
        {
            using (var trans = _organizationRepository.Session.BeginTransaction())
            {
                var id = _organizationRepository.Save(organization);
                trans.Commit();
                return id;
            }
        }

    }
}