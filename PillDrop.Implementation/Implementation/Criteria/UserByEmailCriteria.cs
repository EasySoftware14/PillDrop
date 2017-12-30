using NHibernate;
using NHibernate.Criterion;
using PillDrop.Domain;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class UserByEmailCriteria : ICriteriaSpecification<User>
    {
        private readonly string _email;

        public UserByEmailCriteria(string email)
        {
            _email = email;
        }
        public ICriteria Criteria(ISession session)
        {
            return session.CreateCriteria(typeof(User)).Add(Restrictions.Eq("Email", _email)).
                Add(Restrictions.Eq("Status", EntityStatus.Active));
        }
    }
}
