using FluentNHibernate.Mapping;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Persistence
{
    public class PrescriptionMap : ClassMap<Prescription>
    {
        public PrescriptionMap()
        {
            Table("Formulary");
            Id(x => x.Id).Column("nappi_code");
            Map(x => x.Weight).Column("strength");
            //Map(x => x.Volume).Column("volume");
            Map(x => x.Name).Column("drug_name");

            //Map(x => x.CreatedAt).Column("created_at");
            //Map(x => x.ModifiedAt).Column("modified_at");
        }
    }
}
