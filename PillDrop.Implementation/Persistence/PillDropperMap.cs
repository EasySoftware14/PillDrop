using FluentNHibernate.Mapping;
using PillDrop.Domain;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Persistence
{
    public class PillDropperMap : ClassMap<PillDropper>
    {
        public PillDropperMap()
        {
            Table("[PillDropper]");
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            References(x => x.User).Column("user_id");

            Map(x => x.LicenceNumber).Column("licence_number");
            Map(x => x.VetteCertificate).Column("vette_certificate");
            Map(x => x.LicencePlateNumber).Column("licence_plate_number");
            Map(x => x.CreatedAt).Column("created_at");
            Map(x => x.ModifiedAt).Column("modified_at");
        }

    }
}