using NHibernate;
using NHibernate.Criterion;
using PillDrop.Domain;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class UserForPasswordSetupCriteria : ICriteriaSpecification<User>
    {
        private readonly string _email;
        public UserForPasswordSetupCriteria(string email)
        {
            _email = email;
        }

        public ICriteria Criteria(ISession session)
        {
            var criteria = session.CreateCriteria(typeof(User));
            criteria.Add(Restrictions.Eq("Email", _email))
                .Add(Restrictions.Eq("Status", EntityStatus.Active));
            return criteria;
        }

    }
}