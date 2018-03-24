using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Criteria
{
    public class GetAllPatients: ICriteriaSpecification<Patient>
    {
        public ICriteria Criteria(ISession session)
        {
            var criteria = session.CreateCriteria(typeof(Patient));
            
            return criteria;
        }
    }
}
