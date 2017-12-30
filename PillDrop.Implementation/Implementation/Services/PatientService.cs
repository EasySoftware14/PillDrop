using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IEmailArchiveService _emailArchiveService;

        public PatientService(IPatientRepository patientRepository, IEmailArchiveService emailArchiveService)
        {
            _patientRepository = patientRepository;
            _emailArchiveService = emailArchiveService;
        }
        
        public long Save(Patient user)
        {
            using (var trans = _patientRepository.Session.BeginTransaction())
            {
                var id = _patientRepository.Save(user);
                trans.Commit();
                return id;
            }
        }
       
        public void SaveOrUpdate(Patient user)
        {
            using (var trans = _patientRepository.Session.BeginTransaction())
            {
                _patientRepository.SaveOrUpdate(user);
                trans.Commit();
            }
        }
    }
}