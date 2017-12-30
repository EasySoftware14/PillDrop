﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PillDrop.Domain.Contracts.Models;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Presentation
{
    public class UserModel : IUserModel
    {
        public long Id { get; set; }
        public long OrganizationId { get; set; }
        public string CountryName { get; set; }
        public long RoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string OrganizationName { get; set; }
        public string AdminNumberCode { get; set; }
        public string CountryCode { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public Patient Patient { get; set; }
        public PillDropper PillDropper { get; set; }    
        public EntityStatus Status { get; set; }
        public string Number { get; set; }
        public bool IsSecondaryAdmin { get; set; }
        public bool UseTemporary { get; set; }
        public IList<SelectListItem> RoleList { get; set; }
        public IList<User> Users { get; set; }
        public List<SelectListItem> OrganizationList { get; set; }
        public DateTime? TemporaryPasswordCreatedDate { get; set; }
        public string ExceptionMessage { get; set; }
        public RecoveryQuestion RecoveryQuestion { get; set; }
        public string RecoveryQuestionAnswer { get; set; }

        public UserModel()
        {
            RoleList = new List<SelectListItem>();
            OrganizationList = new List<SelectListItem>();
        }

        public UserModel(User user)
        {
            Id = user.Id;

            //if (user.Organization != null)
            //{
            //    OrganizationId = user.GetOrganizationId();
            //    CountryName = user.GetOrganizationCountryName();
            //    OrganizationName = user.GetOrganizationName();
            //}

            var role = user.UserRoles.Select(x => x.Role).FirstOrDefault();

            if (role != null)
                RoleId = role.Id;

            Name = user.Name;
            Surname = user.Surname;
            IsSecondaryAdmin = user.IsSecondaryAdmin;
            Designation = user.Designation;
            Email = user.Email;
            Number = user.Number;
            CountryCode = user.CountryCode;
            Status = user.Status;
            RecoveryQuestion = user.RecoveryQuestion;
            RecoveryQuestionAnswer = user.RecoveryQuestionAnswer;
        }
    }
}