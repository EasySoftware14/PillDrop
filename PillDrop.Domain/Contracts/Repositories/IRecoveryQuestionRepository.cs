using System.Collections.Generic;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Repositories
{
    public interface IRecoveryQuestionRepository : IRepository<RecoveryQuestion>
    {
        RecoveryQuestion GetQuestionById(long id);
        IList<RecoveryQuestion> GetQuestionsByCriteria();
    }
}