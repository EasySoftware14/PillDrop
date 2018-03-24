using FluentNHibernate.Mapping;
using PillDrop.Domain;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Persistence
{
    public class DemographicsMap : ClassMap<Demography>
    {
        public DemographicsMap()
        {
            Table("[Demographics]");
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
           
            Map(x => x.Code).Column("code");
            Map(x => x.Longitude).Column("longitude");
            Map(x => x.Latitude).Column("latitude");
            Map(x => x.Gps).Column("gps");
            Map(x => x.StandNumber).Column("stand_number");
            
            Map(x => x.CreatedAt).Column("created_at");
            Map(x => x.ModifiedAt).Column("modified_at");
        }

    }
}