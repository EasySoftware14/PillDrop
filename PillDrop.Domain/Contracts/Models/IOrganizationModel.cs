namespace PillDrop.Domain.Contracts.Models
{
    public interface IOrganizationModel
    {
        string Name { get; set; }
        EntityStatus Status { get; set; }
    }
}