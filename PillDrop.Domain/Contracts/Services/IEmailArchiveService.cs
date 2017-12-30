using System.Collections.Generic;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IEmailArchiveService
    {
        IList<EmailArchive> GetEmails();
        void SaveOrUpdate(EmailArchive emailArchive);
        long Save(EmailArchive emailArchive);
    }
}