using FluentNHibernate.Mapping;
using PillDrop.Domain;
using PillDrop.Domain.Entities;

namespace PillDrop.Implementation.Persistence
{
    public class PatientMap : ClassMap<Patient>
    {
        public PatientMap()
        {
            Table("[Patient]");
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            References(x => x.User).Column("user_id");
            References(x => x.Demography).Column("demographics_id");
            Map(x => x.Age).Column("age");
            Map(x => x.Gender).Column("gender");
            Map(x => x.ICD).Column("icd");
            Map(x => x.IsMedicalAid).Column("has_medical_aid");
            
            Map(x => x.CreatedAt).Column("created_at");
            Map(x => x.ModifiedAt).Column("modified_at");
        }

    }
}