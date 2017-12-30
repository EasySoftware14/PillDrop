using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IPatientService
    {
        void SaveOrUpdate(Patient user);
        long Save(Patient user);
        //void SetupEmail(User user);

    }
}