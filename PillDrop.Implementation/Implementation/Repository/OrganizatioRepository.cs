using System.Collections.Generic;
using System.Linq;
using NHibernate;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Entities;
using PillDrop.Implementation.Implementation.Criteria;

namespace PillDrop.Implementation.Implementation.Repository
{
    public class OrganizatioRepository : Repository<Organization>, IOrganizationRepository
    {
        private readonly ISession _session;
        public OrganizatioRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public IList<Organization> GetOrganizations()
        {
            return FindBySpecification(new GetOrganizations()).ToList();
        }

        public Organization GetOrganizationById(long id)
        {
            return FindBySpecification(new OrganizationByIdCriteria(id)).Single();
        }
    }
}