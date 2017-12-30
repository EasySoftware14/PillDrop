using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IDemographicsService
    {
        void SaveOrUpdate(Demography user);
        long Save(Demography user);
        //void SetupEmail(User user);

    }
}