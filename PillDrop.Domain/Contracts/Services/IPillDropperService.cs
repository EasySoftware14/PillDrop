using System.Collections.Generic;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Models;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IPillDropperService
    {
        void SaveOrUpdate(PillDropper user);
        long Save(PillDropper user);
        PillDropper GetPillDropperByUserId(long id);
        IList<PillDropperDataModel> GetAllPillDroppers();
        void SetupEmail(User user, string handler, string culture, string timezone);

    }
}