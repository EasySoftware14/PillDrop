using System.Collections.Generic;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Models;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IPatientService
    {
        void SaveOrUpdate(Patient user);
        long Save(Patient user);
        Patient GetPatientById(long userId);
        IList<PatientDataModel> GetAllPatients();
      
    }
}