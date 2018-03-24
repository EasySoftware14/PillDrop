using System.Collections.Generic;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Repositories
{
    public interface IPrescriptionRepository: IRepository<Prescription>
    {
        IList<Prescription> Prescriptions();
        Prescription GetPrescriptionById(long id);
    }
}