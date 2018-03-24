using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Implementation.Services
{
    public class MedicalService : IMedicalService
    {
        public MedicalService()
        {
            
        }
        public void AssignMedicine(UserPrescription userPrescription)
        {
            throw new NotImplementedException();
        }

        public void SetCollectionDate(User user)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(Prescription address)
        {
            throw new NotImplementedException();
        }

        public long Save(Prescription address)
        {
            throw new NotImplementedException();
        }
    }
}
