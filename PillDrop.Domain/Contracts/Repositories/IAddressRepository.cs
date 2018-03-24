using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        Address GetUserAddressById(long userId);
    }
}