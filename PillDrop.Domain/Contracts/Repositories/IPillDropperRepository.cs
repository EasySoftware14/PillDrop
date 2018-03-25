using System.Collections.Generic;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Models;

namespace PillDrop.Domain.Contracts.Repositories
{
    public interface IPillDrooperRepository : IRepository<PillDropper>
    {
        PillDropper GetPillDropperByUserId(long userId);
        IList<PillDropperDataModel> GetAllPillDroppers();
    }
}