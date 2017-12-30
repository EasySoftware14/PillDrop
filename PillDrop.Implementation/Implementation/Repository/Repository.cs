using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Contracts.Repositories;

namespace PillDrop.Implementation.Implementation.Repository
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public ISession Session
        {
            get
            {
                return _session;
            }
        }

        public T Get(long id)
        {
            return Session.Get<T>(Convert.ToInt64(id));
        }

        public IList<T> GetAllRecords()
        {
            return _session.Query<T>().ToList();
        }
        public T Load(long id)
        {
            return Session.Load<T>(id);
        }

        public long Save(T entity)
        {
            return Convert.ToInt64(Session.Save(entity));
        }

        public IList<T> FindBySpecification(ICriteriaSpecification<T> specification)
        {
            return specification.Criteria(_session).List<T>();
        }

        public string FindStringBySpecification(ICriteriaSpecification<T> specification)
        {
            return specification.Criteria(_session).UniqueResult<string>();
        }

        public long FindCountBySpecification(ICriteriaSpecification<T> specification)
        {
            var count = specification.Criteria(_session).UniqueResult<long>();
            return count;
        }

        public T FindEntityBySpecification(ICriteriaSpecification<T> specification)
        {
            return specification.Criteria(_session).UniqueResult<T>();
        }
        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public void SaveOrUpdate(T item)
        {
            Session.SaveOrUpdate(item);
        }

        public void Delete(T item)
        {
            Session.Delete(item);
        }
    }
}
