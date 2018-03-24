using FluentNHibernate.Mapping;
using PillDrop.Domain;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Models;

namespace PillDrop.Implementation.Persistence
{
    public class PatientDataMap : ClassMap<PatientDataModel>
    {
        public PatientDataMap()
        {
            Table("#PatientData]");
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name");
            Map(x => x.ContactNumber).Column("contact_number");
            Map(x => x.Email).Column("email");
            Map(x => x.Surname).Column("surname");
            
        }

    }
}