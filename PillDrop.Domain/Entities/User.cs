using PillDrop.Domain.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PillDrop.Domain.Entities
{
    public class User : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Number { get; set; }
        public virtual string CountryCode { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string TemporaryPassword { get; set; }
        public virtual int FailedLoginCount { get; set; }
        public virtual DateTime? LockedAt { get; set; }
        public virtual RoleType RoleType { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual PillDropper PillDropper { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual IList<UserRole> UserRoles { get; set; }
        public virtual IList<Feature> UserFeatures { get; set; }
        public virtual EntityStatus Status { get; set; }
        public virtual IEnumerable<Menu> UserModules
        {
            get
            {
                return GetModules();
            }
        }
        public virtual string UserName { get; set; }
        public virtual string CulturePreference { get; set; }
        public virtual string TimeZoneid { get; set; }
        public virtual UserLogin UserLogin { get; set; }
        public virtual string Designation { get; set; }
        public virtual RecoveryQuestion RecoveryQuestion { get; set; }
        public virtual string RecoveryQuestionAnswer { get; set; }
        public virtual bool IsSecondaryAdmin { get; set; }

        public User()
        {
            UserRoles = new List<UserRole>();
            UserFeatures = new List<Feature>();
            
        }
        public virtual IList<string> GetRoles()
        {
            return UserRoles.Select(x => x.Role.Name).ToList();
        }
        public virtual void SetRecoveryQuestion(RecoveryQuestion question)
        {
            RecoveryQuestion = question;
        }
        public virtual void SetHashedRecoveryAnswer(string answer)
        {
            RecoveryQuestionAnswer = answer;
        }
        public virtual void SetStatus(EntityStatus status)
        {
            Status = status;
        }
        public virtual string GetRoleString()
        {
            var roles = UserRoles.Select(x => x.Role.Name);
            return string.Join(",", roles.ToArray());
        }
        public virtual IEnumerable<Menu> GetModules()
        {
            return from role in UserRoles.Select(x => x.Role)
                from roleModule in role.RoleModules
                orderby roleModule.Module.Order ascending
                select
                    new Menu()
                    {
                        Name = roleModule.Module.Name,
                        Controller = roleModule.Module.Controller,
                        Action = roleModule.Module.Action,
                        Order = roleModule.Module.Order,
                        Roles = GetRoleString(),
                        SubMenu = GetSubModules(roleModule)
                    };
        }
        private IList<Menu> GetSubModules(RoleModule roleModule)
        {
            var roleSubModules = roleModule.Role.GetSubModules();
            return (from subModule in roleSubModules
                where subModule.ParentModule.Id == roleModule.Module.Id
                select new Menu()
                {
                    Name = subModule.Name,
                    Controller = subModule.Controller,
                    Action = subModule.Action,
                    Order = roleModule.Module.Order
                }).ToList();
        }
        public virtual void ResetPassword()
        {
            PasswordHash = null;
        }
        public virtual void SetHashedPassword(string password)
        {
            PasswordHash = password;
        }
        public virtual void ResetTemporaryPassword()
        {
            TemporaryPassword = null;
        }
    }

    
}
