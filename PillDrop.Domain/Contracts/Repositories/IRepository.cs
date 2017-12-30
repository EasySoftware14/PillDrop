using System.Collections.Generic;
using NHibernate;

namespace PillDrop.Domain.Contracts.Repositories
{
    public interface IRepository<T>
    {
        T Get(long id);
        T Load(long id);
        long Save(T entity);
        void SaveOrUpdate(T entity);
        void Delete(T entity);
        IList<T> FindBySpecification(ICriteriaSpecification<T> specification);
        IList<T> GetAllRecords();
        long FindCountBySpecification(ICriteriaSpecification<T> specification);
        string FindStringBySpecification(ICriteriaSpecification<T> specification);
        void Update(T entity);
        ISession Session { get; }
        T FindEntityBySpecification(ICriteriaSpecification<T> specification);
    }
}