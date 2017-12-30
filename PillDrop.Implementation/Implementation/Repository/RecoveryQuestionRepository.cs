using System.Collections.Generic;
using System.Linq;
using NHibernate;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Entities;
using PillDrop.Implementation.Implementation.Criteria;

namespace PillDrop.Implementation.Implementation.Repository
{
    public class RecoveryQuestionRepository : Repository<RecoveryQuestion>, IRecoveryQuestionRepository
    {
        public RecoveryQuestionRepository(ISession session)
            : base(session)
        { }

        public RecoveryQuestion GetQuestionById(long id)
        {
            return FindBySpecification(new RecoveryQuestionsByIdCriteria(id)).FirstOrDefault();
        }

        public IList<RecoveryQuestion> GetQuestionsByCriteria()
        {
            return FindBySpecification(new RecoveryQuestionsByCriteria()).ToList();
        }

    }
}