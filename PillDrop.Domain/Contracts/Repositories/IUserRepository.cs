using System.Collections.Generic;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
        User GetUserForPasswordSetup(string email);
        IList<User> GetUsersByRoleType(RoleType type);
        IList<User> GetAllUsers();
    }
}