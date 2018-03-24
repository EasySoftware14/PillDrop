using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Contracts.Models
{
    public interface IAddressModel
    {
        long Id { get; set; }
        string Line1 { get; set; }
        string Line2 { get; set; }
        string Line3 { get; set; }
        string Line4 { get; set; }
        string Line5 { get; set; }
        string ZipCode { get; set; }
        AddressType Type { get; set; }
        string Province { get; set; }
        string City { get; set; }
    }
}