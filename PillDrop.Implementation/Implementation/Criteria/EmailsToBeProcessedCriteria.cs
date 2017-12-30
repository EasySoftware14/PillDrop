using NHibernate;
using NHibernate.Criterion;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class EmailsToBeProcessedCriteria : ICriteriaSpecification<EmailArchive>
    {
        public ICriteria Criteria(ISession session)
        {
            var criteria = session.CreateCriteria(typeof(EmailArchive));
            criteria.Add(Restrictions.Eq("IsSent", false));
            criteria.Add(Restrictions.Lt("RetryCount", 5));
            return criteria;
        }
    }
}