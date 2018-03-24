using NHibernate;
using NHibernate.Criterion;
using PillDrop.Domain;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class GetOrganizations : ICriteriaSpecification<Organization>
    {
        public GetOrganizations()
        {
           
        }
        public ICriteria Criteria(ISession session)
        {
            return session.CreateCriteria(typeof(Organization)).Add(Restrictions.Eq("Status", EntityStatus.Active));
        }
    }
}