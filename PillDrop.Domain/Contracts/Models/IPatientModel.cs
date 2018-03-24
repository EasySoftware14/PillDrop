using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Models
{
    public interface IPatientModel : IUserModel
    {
        Gender Gender { get; set; }
        string Age { get; set; }
        bool IsMedicalAid { get; set; }
        string ICD { get; set; }
    }
}