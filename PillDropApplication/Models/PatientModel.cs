using PillDrop.Domain;
using PillDrop.Domain.Contracts.Models;

namespace PillDropApplication.Models
{
    public class PatientModel : IPatientModel
    {
        public string Gender { get; set; }
        public string Age { get; set; }
        public bool IsMedicalAid { get; set; }
        public string ICD { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CountryCode { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public EntityStatus Status { get; set; }
        public string Number { get; set; }
        public bool IsSecondaryAdmin { get; set; }

        public PatientModel()
        {
        }
    }
}