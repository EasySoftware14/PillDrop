using System.Collections.Generic;
using System.Linq;
using NHibernate;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;
using PillDrop.Implementation.Implementation.Criteria;

namespace PillDrop.Implementation.Implementation.Services
{
    public class PrescriptionService :IPrescriptionService
    {

        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository) 
        {
            _prescriptionRepository = prescriptionRepository;
        }
      
        public IList<Prescription> Prescriptions()
        {
            return _prescriptionRepository.Prescriptions();
        }

        public Prescription GetPrescriptionById(long id)
        {
            return _prescriptionRepository.GetPrescriptionById(id);
        }
    }
}