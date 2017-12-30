namespace PillDrop.Domain.Contracts.Models
{
    public interface IPatientModel : IUserModel
    {
        string Gender { get; set; }
        string Age { get; set; }
        bool IsMedicalAid { get; set; }
        string ICD { get; set; }
    }
}