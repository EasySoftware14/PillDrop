namespace PillDrop.Domain.Contracts.Models
{
    public interface IPillDropperModel
    {
        string LicenceNumber { get; set; }
        string LicencePlateNumber { get; set; }
        bool VetteCertificate { get; set; }
    }
}