using System.Collections.Generic;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Models;

namespace PillDrop.Implementation.Implementation.Services
{
    public class PillDropperService : IPillDropperService
    {
        private readonly IPillDrooperRepository _pillDrooperRepository;
        private readonly IEmailArchiveService _emailArchiveService;

        public PillDropperService(IPillDrooperRepository pillDrooperRepository, IEmailArchiveService emailArchiveService)
        {
            _pillDrooperRepository = pillDrooperRepository;
            _emailArchiveService = emailArchiveService;
        }
        
        public long Save(PillDropper user)
        {
            using (var trans = _pillDrooperRepository.Session.BeginTransaction())
            {
                var id = _pillDrooperRepository.Save(user);
                trans.Commit();
                return id;
            }
        }

        public PillDropper GetPillDropperByUserId(long id)
        {
            return _pillDrooperRepository.Get(id);
        }

        public IList<PillDropperDataModel> GetAllPillDroppers()
        {
            return _pillDrooperRepository.GetAllPillDroppers();
        }

        public void SetupEmail(User user, string handler, string culture, string timezone)
        {
            var email = new EmailArchive()
            {
                ObjectId = user.Id,
                Recipients = user.Email,
                Handler = handler,
                Culture = culture,
                Timezone = timezone
            };
            _emailArchiveService.SaveOrUpdate(email);
        }
        public PillDropper GetById(long id)
        {
            return _pillDrooperRepository.Get(id);
        }
        public void SaveOrUpdate(PillDropper user)
        {
            using (var trans = _pillDrooperRepository.Session.BeginTransaction())
            {
                _pillDrooperRepository.SaveOrUpdate(user);
                trans.Commit();
            }
        }
    }
}