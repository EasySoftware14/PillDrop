using FluentNHibernate.Mapping;
using PillDrop.Domain;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Persistence
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("[User]");
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            //References(x => x.RecoveryQuestion).Column("recovery_question_id");
            References(x => x.Patient).Column("patient_id");
            References(x => x.PillDropper).Column("pilldropper_id");
            Map(x => x.Name).Column("name");
            Map(x => x.Surname).Column("surname");
            Map(x => x.Email).Column("email");
            Map(x => x.Number).Column("contact_number");
            Map(x => x.Status).Column("status").CustomType<EntityStatus>();
            Map(x => x.RoleType).Column("role_id").CustomType<RoleType>();
            Map(x => x.PasswordHash).Column("password_hash");
            Map(x => x.RecoveryQuestionAnswer).Column("recovery_question_answer");
            Map(x => x.TemporaryPassword).Column("temporary_password");
            Map(x => x.CreatedAt).Column("created_at");
            Map(x => x.ModifiedAt).Column("modified_at");
        }

    }
}