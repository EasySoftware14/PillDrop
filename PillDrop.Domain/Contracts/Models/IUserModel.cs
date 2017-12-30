namespace PillDrop.Domain.Contracts.Models
{
    public interface IUserModel
    {
        long Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string CountryCode { get; set; }
        string Designation { get; set; }
        string Email { get; set; }

        EntityStatus Status { get; set; }
        string Number { get; set; }
        bool IsSecondaryAdmin { get; set; }
    }
}