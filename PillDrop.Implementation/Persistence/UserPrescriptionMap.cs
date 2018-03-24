using FluentNHibernate.Mapping;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Persistence
{
    public class UserPrescriptionMap : ClassMap<UserPrescription>
    {
        public UserPrescriptionMap()
        {
            Table("UserPrescription");
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            References(x => x.User).Column("user_id");
            References(x => x.AssignedByUser).Column("assigned_by");

            Map(x => x.Prescription).Column("prescription_id");
            Map(x => x.Collected).Column("collected");
            Map(x => x.DateOfCollection).Column("to_be_collected_on");

            Map(x => x.CreatedAt).Column("created_at");
            Map(x => x.ModifiedAt).Column("modified_at");
        }
    }
}