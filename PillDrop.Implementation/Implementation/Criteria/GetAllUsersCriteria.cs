using NHibernate;
using NHibernate.Criterion;
using PillDrop.Domain;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class GetAllUsersCriteria : ICriteriaSpecification<User>
    {
        public GetAllUsersCriteria()
        {
            
        }
        public ICriteria Criteria(ISession session)
        {
            return session.CreateCriteria(typeof(User)).
                Add(Restrictions.Eq("Status", EntityStatus.Active));
        }
    }
}