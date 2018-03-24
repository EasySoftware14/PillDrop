using NHibernate;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class GetAllPillDroppers : ICriteriaSpecification<PillDropper>
    {
        public ICriteria Criteria(ISession session)
        {
            var criteria = session.CreateCriteria(typeof(PillDropper));
            
            return criteria;
        }
    }
}
