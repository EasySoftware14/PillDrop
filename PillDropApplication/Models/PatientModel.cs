using PillDrop.Domain;
using PillDrop.Domain.Contracts.Models;
using PillDrop.Domain.Entities;

namespace PillDropApplication.Models
{
    public class PatientModel : IPatientModel
    {
        public Gender Gender { get; set; }
        public string Age { get; set; }
        public bool IsMedicalAid { get; set; }
        public string ICD { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CountryCode { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public Demography Demography { get; set; }
        public EntityStatus Status { get; set; }
        public string Number { get; set; }
        public bool IsSecondaryAdmin { get; set; }

        public PatientModel()
        {
        }

        public PatientModel(Patient patient)
        {
            Gender = patient.Gender;
            Age = patient.Age;
            IsMedicalAid = patient.IsMedicalAid;
            ICD = patient.ICD;
            Demography = patient.Demography;
            //Name = pa
        }
    }
}