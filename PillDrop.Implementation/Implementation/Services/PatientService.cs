using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Models;

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

        public Patient GetPatientById(long userId)
        {
            return _patientRepository.Get(userId);
        }

        public IList<PatientDataModel> GetAllPatients()
        {
            return _patientRepository.GetAllPatients();
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