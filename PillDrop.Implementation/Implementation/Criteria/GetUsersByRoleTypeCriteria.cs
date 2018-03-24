using NHibernate;
using NHibernate.Criterion;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class GetUsersByRoleTypeCriteria : ICriteriaSpecification<User>
    {
        private readonly RoleType _roleType;

        public GetUsersByRoleTypeCriteria(RoleType roleType)
        {
            _roleType = roleType;
        }
        public ICriteria Criteria(ISession session)
        {
            var criteria = session.CreateCriteria(typeof(User))
                .Add(Restrictions.Eq("RoleType", _roleType));

            return criteria;
        }
    }
}