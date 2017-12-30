﻿using FluentNHibernate.Mapping;
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
            //References(x => x.Patient).Column("patient_id");
           
            Map(x => x.Code).Column("code");
            Map(x => x.Gps).Column("gps");
            Map(x => x.Location).Column("location");
            Map(x => x.StandNumber).Column("stand_number");
            
            Map(x => x.CreatedAt).Column("created_at");
            Map(x => x.ModifiedAt).Column("modified_at");
        }

    }
}