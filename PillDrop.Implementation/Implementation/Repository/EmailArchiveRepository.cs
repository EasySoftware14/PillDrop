using System.Collections.Generic;
using NHibernate;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Repository
{
    public class EmailArchiveRepository : Repository<EmailArchive>, IEmailArchiveRepository
    {
        public EmailArchiveRepository(ISession session) : base(session)
        {
        }

        public IList<EmailArchive> GetEmailsByCriteria()
        {
            throw new System.NotImplementedException();
        }
    }
}