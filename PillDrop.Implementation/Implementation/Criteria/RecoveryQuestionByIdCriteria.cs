using NHibernate;
using NHibernate.Criterion;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class RecoveryQuestionsByIdCriteria : ICriteriaSpecification<RecoveryQuestion>
    {
        private readonly long _id;

        public RecoveryQuestionsByIdCriteria(long id)
        {
            _id = id;
        }
        public ICriteria Criteria(ISession session)
        {
            return session.CreateCriteria(typeof(RecoveryQuestion)).Add(Restrictions.Eq("id", _id));
        }
    }
}