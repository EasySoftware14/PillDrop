using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Models;
using PillDrop.Implementation.Implementation.Criteria;

namespace PillDrop.Implementation.Implementation.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly ISession _session;

        public PatientRepository(ISession session) : base(session)
        {
            _session = session;
        }

        public Patient GetPatientById(long userId)
        {
            return FindBySpecification(new PatientByIdCriteria(userId)).Single();
        }

        public IList<PatientDataModel> GetAllPatients()
        {
            var sql = "exec [dbo].[get_all_patients]";

            var query = Session
                .CreateSQLQuery(sql)
                .AddEntity(typeof(PatientDataModel))
                .List<PatientDataModel>();

            return query.ToList();
        }
    }
}
