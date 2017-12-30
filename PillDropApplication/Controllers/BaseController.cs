using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Extensions;
using PillDrop.Domain.Presentation;

namespace PillDropApplication.Controllers
{
    public class BaseController : Controller
    {
        public readonly IUserService UserService;

        public BaseController(IUserService userService)
        {
            UserService = userService;
        }

        public User GetPrincipalUser()
        {
            var userIdentity = GetUserIdentity();
            var userId = userIdentity.Id;
            return UserService.GetById(userId);
        }
        public string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }

        public string GetCurrentTimeZone()
        {
            return TimeZoneInfo.Local.Id;
        }
        public UserIdentity GetUserIdentity()
        {
            return (UserIdentity)User.Identity;
        }

        public void ClearSessionVariables()
        {
            Session["Menu"] = null;
            Session["User"] = null;
            Session["NotificationHub"] = null;
            TempData["setupcomplete"] = null;
        }

        public IList<Menu> GetUserModules()
        {
            var user = GetPrincipalUser();
            var modules = user.GetModules();
            return modules.ToList();
        }

        public IList<SelectListItem> GetRoleList()
        {
            var code = Enum.GetValues(typeof(RoleType)).Cast<RoleType>();

            return
                code.Select(
                    item =>
                        new SelectListItem()
                        {
                            Selected = false,
                            Text = item.GetEnumDescription(),
                            Value = item.ToString()

                        }).ToList();
        }
    }
}