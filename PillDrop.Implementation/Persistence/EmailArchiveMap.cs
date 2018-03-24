using FluentNHibernate.Mapping;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Persistence
{
    public class EmailArchiveMap : ClassMap<EmailArchive>
    {
        public EmailArchiveMap()
        {
            Table("EmailArchieve");
            Id(x => x.Id).GeneratedBy.Identity().Column("id");

            Map(x => x.ObjectId).Column("object_id");
            Map(x => x.Recipients).Column("recipients");
            Map(x => x.Handler).Column("handler");

            Map(x => x.CreatedAt).Column("created_at");
            Map(x => x.ModifiedAt).Column("modified_at");

        }
    }
}