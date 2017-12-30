using System.Collections.Generic;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Services
{
    public class RecoveryQuestionService : IRecoveryQuestionService
    {
        private readonly IRecoveryQuestionRepository _recoveryquestionRepository;
        private readonly IEmailArchiveService _emailArchiveService;

        public RecoveryQuestionService(IRecoveryQuestionRepository recoveryquestionRepository, IEmailArchiveService emailArchiveService)
        {
            _recoveryquestionRepository = recoveryquestionRepository;
            _emailArchiveService = emailArchiveService;

        }

        public RecoveryQuestion GetQuestionById(long id)
        {
            return _recoveryquestionRepository.GetQuestionById(id);
        }

        public IList<RecoveryQuestion> GetQuestionsByCriteria()
        {
            return _recoveryquestionRepository.GetQuestionsByCriteria();
        }

        public long Save(RecoveryQuestion recoveryquestion)
        {
            using (var trans = _recoveryquestionRepository.Session.BeginTransaction())
            {
                var id = _recoveryquestionRepository.Save(recoveryquestion);
                trans.Commit();
                return id;
            }
        }

        public IList<RecoveryQuestion> GetQuestions()
        {
            return _recoveryquestionRepository.GetQuestionsByCriteria();
        }

        public void SaveOrUpdate(RecoveryQuestion recoveryquestion)
        {
            using (var trans = _recoveryquestionRepository.Session.BeginTransaction())
            {
                _recoveryquestionRepository.SaveOrUpdate(recoveryquestion);
                trans.Commit();
            }
        }
    }
}