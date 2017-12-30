using System.Collections.Generic;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Services
{
    public class EmailArchiveService : IEmailArchiveService
    {
        private readonly IEmailArchiveRepository _emailArchiveRepository;

        public EmailArchiveService(IEmailArchiveRepository emailArchiveRepository)
        {
            _emailArchiveRepository = emailArchiveRepository;
        }

        public IList<EmailArchive> GetEmails()
        {
            return _emailArchiveRepository.GetEmailsByCriteria();
        }

        public void SaveOrUpdate(EmailArchive emailArchive)
        {
            using (var trans = _emailArchiveRepository.Session.BeginTransaction())
            {
                _emailArchiveRepository.SaveOrUpdate(emailArchive);
                trans.Commit();
            }
        }

        public long Save(EmailArchive emailArchive)
        {
            using (var trans = _emailArchiveRepository.Session.BeginTransaction())
            {
                var id = _emailArchiveRepository.Save(emailArchive);
                trans.Commit();
                return id;
            }
        }
    }
}