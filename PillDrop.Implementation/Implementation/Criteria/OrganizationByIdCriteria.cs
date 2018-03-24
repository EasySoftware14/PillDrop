using NHibernate;
using NHibernate.Criterion;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class OrganizationByIdCriteria : ICriteriaSpecification<Organization>
    {
        private readonly long _id;

        public OrganizationByIdCriteria(long id)
        {
            _id = id;
        }
        public ICriteria Criteria(ISession session)
        {
            return session.CreateCriteria(typeof(Organization)).Add(Restrictions.Eq("id", _id));
        }
    }
}