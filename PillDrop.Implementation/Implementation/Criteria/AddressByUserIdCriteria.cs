using NHibernate;
using NHibernate.Criterion;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class AddressByUserIdCriteria : ICriteriaSpecification<Address>
    {
        private readonly long _id;

        public AddressByUserIdCriteria(long id)
        {
            _id = id;
        }
        public ICriteria Criteria(ISession session)
        {
            return session.CreateCriteria(typeof(Address)).Add(Restrictions.Eq("user_id", _id));
        }
    }
}