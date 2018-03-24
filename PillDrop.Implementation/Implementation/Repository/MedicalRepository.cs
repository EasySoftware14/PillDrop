using System;
using NHibernate;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Repository
{
    public class MedicalRepository : Repository<UserPrescription>, IMedicalRepository
    {
        private readonly ISession _session;

        public MedicalRepository(ISession session) : base(session)
        {
            _session = session;
        }
        public void AssignMedicine(UserPrescription userPrescription)
        {
            throw new NotImplementedException();
        }

        public void SetCollectionDate(User user)
        {
            throw new NotImplementedException();
        }
    }
}
