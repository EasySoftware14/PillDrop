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
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private readonly ISession _session;

        public AddressRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public Address GetUserAddressById(long userId)
        {
            return FindBySpecification(new AddressByUserIdCriteria(userId)).Single();
        }
    }
}
