using PillDrop.Domain.Contracts;
using PillDrop.Domain.Contracts.Models;

namespace PillDrop.Domain.Entities
{
    public class Address : Entity
    {
        public virtual User User { get; set; }
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string Line3 { get; set; }
        public virtual string Line4 { get; set; }
        public virtual string Line5 { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual AddressType Type { get; set; }
        public virtual string Province { get; set; }
        public virtual string City { get; set; }

        public virtual void Update(IAddressModel model)
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

        public virtual void SetAddressType(AddressType addresstype)
        {
            Type = addresstype;
        }
    }

    
}