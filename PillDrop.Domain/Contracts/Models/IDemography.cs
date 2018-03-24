namespace PillDrop.Domain.Contracts.Models
{
    public interface IDemography
    {
        string StandNumber { get; set; }
        string Location { get; set; }
        string Code { get; set; }
        string Gps { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }
    }
}