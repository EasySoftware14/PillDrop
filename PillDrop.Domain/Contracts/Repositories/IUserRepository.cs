using System.Collections.Generic;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
        void SaveOrUpdate(User user);
        long Save(User user);
        User GetUserForPasswordSetup(string email);
        IList<User> GetAllUsers();
    }
}