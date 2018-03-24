using System.Collections.Generic;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IUserPrescriptionService
    {
        IList<Prescription> GetAllMedicineByUser(User user);
        UserPrescription GetUserPrescriptionById(long id);
        IList<UserPrescription> GetAllUserPrescriptions();
        IList<UserPrescription> GetAllUserPrescriptionsByCriteria(IUserSearchCriteria criteria);
        long Save(UserPrescription userMedicine);
        void SaveOrUpdate(UserPrescription userMedicine);
    }
}