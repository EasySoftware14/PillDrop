using System.Collections.Generic;
using PillDrop.Domain.Contracts.Models;

namespace PillDrop.Domain.Entities
{
    public class Patient : Entity
    {
        public virtual User User { get; set; }  
        public virtual bool IsMedicalAid { get; set; }
        public virtual string ICD { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Demography Demography { get; set; }
        public virtual string Age { get; set; }
   

        public Patient()
        {
           
        }
        
        public virtual void Update(IPatientModel model)
        {
            IsMedicalAid = model.IsMedicalAid;
            ICD = model.ICD;
            Gender = model.Gender;
            Age = model.Age;
        }

        public virtual void SetDemographics(Demography demography)
        {
            Demography = demography;
        }
        public virtual void SetUsers(User user)
        {
            User = user;
        }
    }
}