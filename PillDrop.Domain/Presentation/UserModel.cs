using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using PillDrop.Domain.Contracts.Models;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Models;

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
        [Range(1, int.MaxValue, ErrorMessage = "Select a gender")]
        public Gender Gender { get; set; }
        public string Age { get; set; }
        public Patient Patient { get; set; }
        public Address Address { get; set; }    
        public PillDropper PillDropper { get; set; }
        public EntityStatus Status { get; set; }
        public RoleType RoleType { get; set; }
        public IList<SelectListItem> NetworkCodes { get; set; }
        public string Number { get; set; }
        public string CellCode { get; set; }
        public string CellNumber { get; set; }
        public string NationalCode { get; set; }
        public bool IsSecondaryAdmin { get; set; }
        public bool UseTemporary { get; set; }
        public IList<SelectListItem> RoleList { get; set; }
        public IList<SelectListItem> CodesList { get; set; }
        public IList<User> Users { get; set; }
        public IList<PatientDataModel> Patients { get; set; }
        public IList<PillDropperDataModel> PillDroppers { get; set; }
        public IList<SelectListItem> OrganizationList { get; set; }
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

            if (user.Organization != null) 
            {
                OrganizationId = user.GetOrganizationId();
                OrganizationName = user.Name;
            }

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
            RoleType = user.RoleType;
            Address = user.Address;
            PillDropper = user.PillDropper ?? new PillDropper();
            Patient = user.Patient ?? new Patient();
            Gender = user.Gender;
        }

        public List<SelectListItem> SetCode()
        {
            var enumList = new List<SelectListItem>();
            enumList.Add(new SelectListItem { Text = "060" });
            enumList.Add(new SelectListItem { Text = "074" });
            enumList.Add(new SelectListItem { Text = "084" });
            enumList.Add(new SelectListItem { Text = "083" });
            enumList.Add(new SelectListItem { Text = "073" });
            enumList.Add(new SelectListItem { Text = "081" });
            enumList.Add(new SelectListItem { Text = "063" });
            enumList.Add(new SelectListItem { Text = "071" });
            enumList.Add(new SelectListItem { Text = "079" });
            enumList.Add(new SelectListItem { Text = "061" });
            enumList.Add(new SelectListItem { Text = "072" });
            enumList.Add(new SelectListItem { Text = "078" });

            return enumList;
        }
        

    }
}