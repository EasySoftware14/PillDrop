using System.Collections.Generic;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Repositories
{
    public interface IEmailArchiveRepository : IRepository<EmailArchive>
    {
        IList<EmailArchive> GetEmailsByCriteria();
    }
}