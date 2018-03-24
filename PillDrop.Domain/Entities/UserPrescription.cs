using System;
using PillDrop.Domain.Contracts.Models;

namespace PillDrop.Domain.Entities
{
    public class UserPrescription : Entity
    {
        public virtual User User { get; set; }
        public virtual string Prescription { get; set; }
        public virtual User AssignedByUser  { get; set; }
        public virtual DateTime DateOfCollection{ get; set; }
        public virtual bool Collected { get; set; }

        public virtual void Update(IUserPrescriptionModel model)
        {
            User = model.User;
            Prescription = model.Prescription;
            AssignedByUser = model.AssignedBy;
            DateOfCollection = model.DateOfCollection;
            Collected = model.Collected;
        }
    }
}