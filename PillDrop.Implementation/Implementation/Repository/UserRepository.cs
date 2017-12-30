using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Entities;
using PillDrop.Implementation.Implementation.Criteria;

namespace PillDrop.Implementation.Implementation.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ISession _session;

        public UserRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public User GetByEmail(string email)
        {
            return FindBySpecification(new UserByEmailCriteria(email)).FirstOrDefault();
        }

        public User GetUserForPasswordSetup(string email)
        {
            return FindBySpecification(new UserForPasswordSetupCriteria(email)).FirstOrDefault();
        }

        public IList<User> GetAllUsers()
        {
            return FindBySpecification(new GetAllUsersCriteria()).ToList();
        }
    }
}
