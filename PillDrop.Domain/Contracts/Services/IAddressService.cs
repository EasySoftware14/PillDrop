using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Services
{
    public interface IAddressService
    {
        void SaveOrUpdate(Address address);
        long Save(Address address);
        Address GetUserAddressById(long id);
        //void SetupEmail(User user);

    }
}