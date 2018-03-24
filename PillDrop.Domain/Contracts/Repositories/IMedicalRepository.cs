using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Repositories
{
    public interface IMedicalRepository
    {
        void AssignMedicine(UserPrescription userPrescription);
        void SetCollectionDate(User user);
    }
}