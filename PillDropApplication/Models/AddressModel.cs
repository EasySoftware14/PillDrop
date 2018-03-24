using PillDrop.Domain.Contracts.Models;
using PillDrop.Domain.Entities;

namespace PillDropApplication.Models
{
    public class AddressModel : IAddressModel
    {
        public long Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string Line5 { get; set; }
        public string ZipCode { get; set; }
        public AddressType Type { get; set; }
        public string Province { get; set; }
        public string City { get; set; }

        public AddressModel()
        {
            
        }

        public AddressModel(Address model)
        {
            Line1 = model.Line1;
            Line2 = model.Line2;
            Line3 = model.Line3;
            Line4 = model.Line4;
            Line5 = model.Line5;
            Province = model.Province;
            City = model.City;
            ZipCode = model.ZipCode;
            Type = model.Type;
        }
    }
}