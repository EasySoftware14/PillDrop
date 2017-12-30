using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IPillDropperService
    {
        void SaveOrUpdate(PillDropper user);
        long Save(PillDropper user);
        void SetupEmail(User user, string handler, string culture, string timezone);

    }
}