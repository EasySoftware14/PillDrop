using System.Collections.Generic;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IPrescriptionService
    {
        IList<Prescription> Prescriptions();
        Prescription GetPrescriptionById(long id);
    }
}