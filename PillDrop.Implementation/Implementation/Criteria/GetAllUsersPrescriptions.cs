using NHibernate;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class GetAllUsersPrescriptions : ICriteriaSpecification<UserPrescription>
    {

        public GetAllUsersPrescriptions()
        {
            
        }

        public ICriteria Criteria(ISession session)
        {
            return session.CreateCriteria(typeof(UserPrescription));
        }
    }
}