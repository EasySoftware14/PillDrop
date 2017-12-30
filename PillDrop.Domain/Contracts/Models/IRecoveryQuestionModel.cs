namespace PillDrop.Domain.Contracts.Models
{
    public interface IRecoveryQuestionModel
    {
        long Id { get; set; }
        string Question { get; set; }
        EntityStatus Status { get; set; }
    }
}