using NHibernate;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class GetPrescriptionListCriteria : ICriteriaSpecification<Prescription>
    {
        public GetPrescriptionListCriteria()
        {
            
        }
        public ICriteria Criteria(ISession session)
        {
            return session.CreateCriteria(typeof(Prescription));
        }
    }
}