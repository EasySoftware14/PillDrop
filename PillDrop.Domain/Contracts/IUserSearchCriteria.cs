using System;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts
{
    public interface IUserSearchCriteria
    {
        User User { get; set; }
        string Name { get; set; }
        DateTime ColletionDate { get; set; }

    }
}