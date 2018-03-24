using System.Collections.Generic;
using System.Linq;
using NHibernate;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Entities;
using PillDrop.Implementation.Implementation.Criteria;

namespace PillDrop.Implementation.Implementation.Repository
{
    public class UserPrescriptionRepository : Repository<UserPrescription>, IUserPrescriptionRepository
    {
        private readonly ISession _session;

        public UserPrescriptionRepository(ISession session): base(session)
        {
            _session = session;
        }

        public IList<Prescription> GetAllMedicineByUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public IList<UserPrescription> GetAllUserPrescriptions() => FindBySpecification(new GetAllUsersPrescriptions()).ToList();

        public IList<UserPrescription> GetAllUserPrescriptionsByCriteria(IUserSearchCriteria criteria)
        {
            throw new System.NotImplementedException();
        }
    }
}