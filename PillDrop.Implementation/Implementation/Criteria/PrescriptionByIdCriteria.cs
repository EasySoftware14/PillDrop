using NHibernate;
using NHibernate.Criterion;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class PrescriptionByIdCriteria : ICriteriaSpecification<Prescription>
    {
        private readonly long _id;

        public PrescriptionByIdCriteria(long id)
        {
            _id = id;
        }
        public ICriteria Criteria(ISession session)
        {
            var criteria = session.CreateCriteria(typeof(Prescription));
            criteria.Add(Restrictions.Eq("Id", _id));

            return criteria;
        }
    }
}