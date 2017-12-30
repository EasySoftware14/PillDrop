using FluentNHibernate.Mapping;
using PillDrop.Domain;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Persistence
{
    public class RecoveryQuestionMap : ClassMap<RecoveryQuestion>
    {
        public RecoveryQuestionMap()
        {
            Table("[RecoveryQuestion]");
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            Map(x => x.Question).Column("question");
            Map(x => x.CreatedAt).Column("created_at");
            Map(x => x.ModifiedAt).Column("modified_at");
            Map(x => x.Status).Column("[status]").CustomType<EntityStatus>();
        }
    }
}