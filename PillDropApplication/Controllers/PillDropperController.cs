using System;
using System.Configuration;
using System.Globalization;
using System.Web.Mvc;
using GoogleMaps.LocationServices;
using PillDrop.Domain;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Presentation;
using PillDropApplication.Models;

namespace PillDropApplication.Controllers
{
    public class PillDropperController : BaseController
    {
        private readonly IAddressService _addressService;
        private readonly IPillDropperService _pillDropperService;
        private readonly IGeographicalService _geographicalService;

        public PillDropperController(IUserService userService, IAddressService addressService, IPillDropperService pillDropperService, IGeographicalService geographicalService) : base(userService)
        {
            _addressService = addressService;
            _pillDropperService = pillDropperService;
            _geographicalService = geographicalService;
        }

        public ActionResult Index()
        {
            var model = new UserModel();
            model.NetworkCodes = model.SetCode();

            return View("Create", model);
        }
        public ActionResult List()
        {
            var model = new UserModel();
            var pilldroppers = _pillDropperService.GetAllPillDroppers();

            model.PillDroppers = pilldroppers;
            return View(model);
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            var line1 = model.Address.Line1;
            var line2 = model.Address.Line2;

            var latLong = _geographicalService.GetMapPoints(line1 + "," + line2);
            var latitude = string.Empty;
            var longitude = string.Empty;

            if (latLong != null)
            {
                latitude = Convert.ToString(latLong.Latitude, CultureInfo.InvariantCulture);
                longitude = Convert.ToString(latLong.Longitude, CultureInfo.InvariantCulture);
            }

            var number = model.NationalCode + model.CellCode + model.CellNumber;

            var user = new User
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Number = number,
                Status = EntityStatus.InActive,
                RoleType = RoleType.PillDropper,
                Gender = model.Gender

            };
            UserService.SaveOrUpdate(user);

            var pillDropper = new PillDropper
            {
                LicencePlateNumber = model.PillDropper.LicencePlateNumber,
                LicenceNumber = model.PillDropper.LicenceNumber,
                User = user,
                VetteCertificate = model.PillDropper.VetteCertificate,
                Latitude = latitude,
                Longitude = longitude

            };
            var address = new Address
            {
                Line1 = model.Address.Line1,
                Line2 = model.Address.Line2,
                Line3 = model.Address.Line3,
                Line4 = model.Address.Line4,
                Line5 = model.Address.Line5,
                Province = model.Address.Province,
                City = model.Address.City,
                ZipCode = model.Address.ZipCode,
                User = user
            };

            _addressService.SaveOrUpdate(address);
            _pillDropperService.SaveOrUpdate(pillDropper);

            user.SetPillDropper(pillDropper);
            user.SetAddress(address);
            UserService.SaveOrUpdate(user);

            var path = string.Format("{0}PillDropperEmail.txt", ConfigurationManager.AppSettings["email_templates_path"]);

            UserService.SetupEmail(user, path);
            TempData["Success"] = true;
            return RedirectToAction("login","Auth");
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var distance = _geographicalService.GetCoordinate(
                new MapPoint {Latitude = -34.0169629, Longitude = 18.636389},
                new MapPoint {Latitude = -34.0169629, Longitude = 18.636389});
            var user = UserService.GetById(id);
            var model = new UserModel(user);

            return View(model);
        }
        public ActionResult View(long id)
        {
            var user = UserService.GetById(id);
            var model = new UserModel(user);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserModel model)
        {
            var user = UserService.GetById(model.Id);
            var address = _addressService.GetUserAddressById(user.Address.Id) ??
                          new Address
                          {
                              Line1 = model.Address.Line1,
                              Line2 = model.Address.Line2,
                              Line3 = model.Address.Line3,
                              Line4 = model.Address.Line4,
                              Line5 = model.Address.Line5,
                              Province = model.Address.Province,
                              City = model.Address.City,
                              ZipCode = model.Address.ZipCode,
                              User = user
                          };
            var pillDropper = _pillDropperService.GetPillDropperByUserId(user.PillDropper.Id);
            var pillDropperModel = new PillDropperModel(model.PillDropper);
            var addressModel = new AddressModel(model.Address);

            pillDropper.Update(pillDropperModel);
            _pillDropperService.SaveOrUpdate(pillDropper);
            address.Update(addressModel);

            user.Update(model);
            UserService.SaveOrUpdate(user);

            return RedirectToAction("Index");
        }

    }
}