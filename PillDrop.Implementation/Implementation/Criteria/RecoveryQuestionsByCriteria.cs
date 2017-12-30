using NHibernate;
using NHibernate.Criterion;
using PillDrop.Domain;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class RecoveryQuestionsByCriteria : ICriteriaSpecification<RecoveryQuestion>
    {
        public ICriteria Criteria(ISession session)
        {
            var criteria = session.CreateCriteria(typeof(RecoveryQuestion));
            criteria.Add(Restrictions.Eq("Status", EntityStatus.Active));
            return criteria;
        }
    }
}