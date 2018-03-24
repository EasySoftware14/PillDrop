using System.Collections.Generic;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Services
{
    public class UserPrescriptionService : IUserPrescriptionService
    {
        private readonly IUserPrescriptionRepository _prescriptionRepository;

        public UserPrescriptionService(IUserPrescriptionRepository userPrescriptionRepository)
        {
            _prescriptionRepository = userPrescriptionRepository;
        }
        public IList<Prescription> GetAllMedicineByUser(User user)
        {
            return _prescriptionRepository.GetAllMedicineByUser(user);
        }

        public UserPrescription GetUserPrescriptionById(long id)
        {
            return _prescriptionRepository.Get(id);
        }
        public IList<UserPrescription> GetAllUserPrescriptions()
        {
            return _prescriptionRepository.GetAllUserPrescriptions();
        }

        public IList<UserPrescription> GetAllUserPrescriptionsByCriteria(IUserSearchCriteria criteria)
        {
            throw new System.NotImplementedException();
        }

        public long Save(UserPrescription userMedicine)
        {
            using (var trans = _prescriptionRepository.Session.BeginTransaction())
            {
                var id = _prescriptionRepository.Save(userMedicine);
                trans.Commit();
                return id;
            };
        }

        public void SaveOrUpdate(UserPrescription userPrescription)
        {
            using (var trans = _prescriptionRepository.Session.BeginTransaction())
            {
                 _prescriptionRepository.SaveOrUpdate(userPrescription);
                trans.Commit();
               
            };
        }
    }
}