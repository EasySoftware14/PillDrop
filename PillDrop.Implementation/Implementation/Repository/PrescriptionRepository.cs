using System.Collections.Generic;
using System.Linq;
using NHibernate;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Entities;
using PillDrop.Implementation.Implementation.Criteria;

namespace PillDrop.Implementation.Implementation.Repository
{
    public class PrescriptionRepository : Repository<Prescription>, IPrescriptionRepository
    {

        private readonly ISession _session;

        public PrescriptionRepository(ISession session) : base(session)
        {
            _session = session;
        }
      
        public IList<Prescription> Prescriptions()
        {
            return FindBySpecification(new GetPrescriptionListCriteria()).ToList();
        }

        public Prescription GetPrescriptionById(long id)
        {
            return FindEntityBySpecification(new PrescriptionByIdCriteria(id));
        }
    }
}