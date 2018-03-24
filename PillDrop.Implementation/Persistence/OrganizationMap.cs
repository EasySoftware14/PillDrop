using FluentNHibernate.Mapping;
using PillDrop.Domain;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Persistence
{
    public class OrganizationMap : ClassMap<Organization>
    {
        public OrganizationMap()
        {
            Table("[Organization]");
            Id(x => x.Id).GeneratedBy.Identity().Column("id");

            Map(x => x.Name).Column("name");
            Map(x => x.Status).Column("[status]").CustomType<EntityStatus>();
            Map(x => x.CreatedAt).Column("created_at");
            Map(x => x.ModifiedAt).Column("modified_at");

        }
    }
}