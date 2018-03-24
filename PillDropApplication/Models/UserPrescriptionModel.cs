using System;
using System.Collections.Generic;
using PillDrop.Domain.Contracts.Models;
using PillDrop.Domain.Entities;

namespace PillDropApplication.Models
{
    public class UserPrescriptionModel : IUserPrescriptionModel
    {
        public long Id { get; set; }    
        public string Prescription { get; set; }
        public User AssignedBy { get; set; }
        public User User { get; set; }
        public DateTime DateOfCollection { get; set; }
        public bool Collected { get; set; }
        public IList<UserPrescription> UserPrescriptions { get; set; }
        public IList<Prescription> SelectedPrescriptions { get; set; }
        public string DateCollectionSet { get; set; }
        public IList<PrescriptionModel> Prescriptions { get; set; }
        public string  FullName { get; set; }
        public IList<string> ListOfCollectionDate { get; set; }
        public UserPrescriptionModel()
        {

            UserPrescriptions = new List<UserPrescription>();
        }

        public UserPrescriptionModel(UserPrescription prescription)
        {
            Prescription = prescription.Prescription;
            AssignedBy = prescription.AssignedByUser;
            User = prescription.User;
            DateOfCollection = prescription.DateOfCollection;
            Collected = prescription.Collected;
        }


    }
}