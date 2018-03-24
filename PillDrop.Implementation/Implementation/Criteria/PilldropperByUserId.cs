using NHibernate;
using NHibernate.Criterion;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class PilldropperByUserId : ICriteriaSpecification<PillDropper>
    {
        private readonly long _id;

        public PilldropperByUserId(long id)
        {
            _id = id;
        }
        public ICriteria Criteria(ISession session)
        {
            return session.CreateCriteria(typeof(PillDropper)).Add(Restrictions.Eq("user_id", _id));
        }
    }
}