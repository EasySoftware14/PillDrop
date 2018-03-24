using FluentNHibernate.Mapping;
using PillDrop.Domain;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Persistence
{
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Table("[Address]");
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            References(x => x.User).Column("user_id");
            Map(x => x.Line1).Column("line_1");
            Map(x => x.Line2).Column("line_2");
            Map(x => x.Line3).Column("line_3");
            Map(x => x.Line4).Column("line_4");
            Map(x => x.Line5).Column("line_5");
            Map(x => x.Type).Column("[type]").CustomType<AddressType>();
            Map(x => x.ZipCode).Column("zip_code");
            Map(x => x.City).Column("city");
            Map(x => x.Province).Column("province");
            Map(x => x.CreatedAt).Column("created_at");
            Map(x => x.ModifiedAt).Column("modified_at");
  
        }

    }
}