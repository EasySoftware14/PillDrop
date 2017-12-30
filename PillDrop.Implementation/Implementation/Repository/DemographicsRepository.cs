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
    public class DemographicsRepository : Repository<Demography>, IDemographicsRepository
    {
        private readonly ISession _session;

        public DemographicsRepository(ISession session) : base(session)
        {
            _session = session;
        }
       
    }
}
