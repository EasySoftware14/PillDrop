using System.Collections.Generic;
using System.Linq;
using NHibernate;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Models;
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

        public PillDropper GetPillDropperByUserId(long userId)
        {
            return FindBySpecification(new PilldropperByUserId(userId)).Single();
        }

        public IList<PillDropperDataModel> GetAllPillDroppers()
        {
            var sql = "exec [dbo].[get_pilldropper]";

            var query = Session
                .CreateSQLQuery(sql)
                .AddEntity(typeof(PillDropperDataModel))
                .List<PillDropperDataModel>();

            return query.ToList();
            //return FindBySpecification(new GetAllPillDroppers()).ToList();
        }
    }
}
