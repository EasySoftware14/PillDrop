using System.Collections.Generic;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IRecoveryQuestionService
    {
        RecoveryQuestion GetQuestionById(long id);
        IList<RecoveryQuestion> GetQuestionsByCriteria();
        IList<RecoveryQuestion> GetQuestions();
        void SaveOrUpdate(RecoveryQuestion recoveryquestion);
        long Save(RecoveryQuestion recoveryquestion);
    }
}