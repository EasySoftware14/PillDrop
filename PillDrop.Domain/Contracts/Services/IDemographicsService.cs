using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IDemographicsService
    {
        void SaveOrUpdate(Demography demography);
        long Save(Demography demography);
        Demography GetById(long id);
        //void SetupEmail(User user);

    }
}