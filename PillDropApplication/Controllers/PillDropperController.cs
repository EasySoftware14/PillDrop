using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PillDrop.Domain.Contracts.Services;

namespace PillDropApplication.Controllers
{
    public class PillDropperController : BaseController
    {
       
        public PillDropperController(IUserService userService) : base(userService)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        
    }
}