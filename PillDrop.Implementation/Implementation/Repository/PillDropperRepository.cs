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
    public class PillDropperRepository : Repository<PillDropper>, IPillDrooperRepository
    {
        private readonly ISession _session;

        public PillDropperRepository(ISession session) : base(session)
        {
            _session = session;
        }
       
    }
}
