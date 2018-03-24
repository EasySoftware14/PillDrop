using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IEmailArchiveService _emailArchiveService;

        public AddressService(IAddressRepository addressRepository, IEmailArchiveService emailArchiveService)
        {
            _addressRepository = addressRepository;
            _emailArchiveService = emailArchiveService;
        }
        
        public long Save(Address address)
        {
            using (var trans = _addressRepository.Session.BeginTransaction())
            {
                var id = _addressRepository.Save(address);
                trans.Commit();
                return id;
            }
        }

        public Address GetUserAddressById(long id)
        {
            return _addressRepository.Get(id);
        }

        public void SaveOrUpdate(Address address)
        {
            using (var trans = _addressRepository.Session.BeginTransaction())
            {
                _addressRepository.SaveOrUpdate(address);
                trans.Commit();
            }
        }
    }
}