using System.Collections.Generic;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Repositories
{
    public interface IUserPrescriptionRepository : IRepository<UserPrescription>
    {
        IList<Prescription> GetAllMedicineByUser(User user);
        IList<UserPrescription> GetAllUserPrescriptions();
        IList<UserPrescription> GetAllUserPrescriptionsByCriteria(IUserSearchCriteria criteria);
    }
}