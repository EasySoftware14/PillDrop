using NHibernate;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class GetAllUsersPrescriptionsByCriteria : ICriteriaSpecification<UserPrescription>
    {
        private readonly IUserSearchCriteria _criteria;

        public GetAllUsersPrescriptionsByCriteria(IUserSearchCriteria criteria)
        {
            _criteria = criteria;
        }

        public ICriteria Criteria(ISession session)
        {
            var criteria = session.CreateCriteria(typeof(UserPrescription));



            return criteria;
        }
    }
}