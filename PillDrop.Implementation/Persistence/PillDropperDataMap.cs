﻿using FluentNHibernate.Mapping;
using PillDrop.Domain;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Models;

namespace PillDrop.Implementation.Persistence
{
    public class PillDropperDataMap : ClassMap<PillDropperDataModel>
    {
        public PillDropperDataMap()
        {
            Table("#PillDropperData]");
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            Map(x => x.Name).Column("Name");
            Map(x => x.ContactNumber).Column("contact_number");
            Map(x => x.Email).Column("email");
            Map(x => x.Surname).Column("surname");
            
        }

    }
}