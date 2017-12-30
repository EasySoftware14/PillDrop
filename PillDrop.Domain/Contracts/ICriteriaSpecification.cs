using NHibernate;

namespace PillDrop.Domain.Contracts
{
    public interface ICriteriaSpecification<T>
    {
        ICriteria Criteria(ISession session);
    }
}