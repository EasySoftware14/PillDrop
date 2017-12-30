using PillDrop.Domain.Entities;
using System.Collections.Generic;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IUserService
    {
        User GetByEmail(string email);
        User GetById(long id);
        IList<User> GetAllUsers();
        void SaveOrUpdate(User user);
        User GetUserForPasswordSetup(string email);
        long Save(User user);
        void SetupEmail(User user);

    }
}