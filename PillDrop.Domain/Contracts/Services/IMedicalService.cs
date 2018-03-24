using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IMedicalService
    {
        void AssignMedicine(UserPrescription userPrescription);
        void SetCollectionDate(User user);
        void SaveOrUpdate(Prescription address);
        long Save(Prescription address);
    }
}