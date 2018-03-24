using System.Collections.Generic;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Models;

namespace PillDrop.Domain.Contracts.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Patient GetPatientById(long userId);
        IList<PatientDataModel> GetAllPatients();
    }
}