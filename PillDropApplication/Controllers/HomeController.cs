using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;
using PillDrop.Domain.Contracts.Services;

namespace PillDropApplication.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            var user = Session["User"];
            if (user == null) return RedirectToAction("Logout", "Auth");
            ViewBag.Success = TempData["Success"];

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login Page";

            return View("Login");
        }

        
    }
}