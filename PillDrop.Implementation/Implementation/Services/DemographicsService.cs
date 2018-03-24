using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Services
{
    public class DemographicsService : IDemographicsService
    {
        private readonly IDemographicsRepository _demographicsRepository;
        private readonly IEmailArchiveService _emailArchiveService;

        public DemographicsService(IDemographicsRepository demographicsRepository, IEmailArchiveService emailArchiveService)
        {
            _demographicsRepository = demographicsRepository;
            _emailArchiveService = emailArchiveService;
        }
        
        public long Save(Demography demography)
        {
            using (var trans = _demographicsRepository.Session.BeginTransaction())
            {
                var id = _demographicsRepository.Save(demography);
                trans.Commit();
                return id;
            }
        }

        public Demography GetById(long id)
        {
            return _demographicsRepository.Get(id);
        }

        public void SaveOrUpdate(Demography demography)
        {
            using (var trans = _demographicsRepository.Session.BeginTransaction())
            {
                _demographicsRepository.SaveOrUpdate(demography);
                trans.Commit();
            }
        }
    }
}