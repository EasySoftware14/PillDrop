using NHibernate;
using NHibernate.Criterion;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class PatientByIdCriteria : ICriteriaSpecification<Patient>
    {
        private readonly long _id;

        public PatientByIdCriteria(long id)
        {
            _id = id;
        }
        public ICriteria Criteria(ISession session)
        {
            return session.CreateCriteria(typeof(Patient)).Add(Restrictions.Eq("user_id", _id));
        }
    }
}