using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoogleMaps.LocationServices;
using PillDrop.Domain;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Presentation;
using PillDropApplication.Models;

namespace PillDropApplication.Controllers
{
    public class PatientController : BaseController
    {
        private readonly IAddressService _addressService;
        private readonly IPatientService _patientService;
        private readonly IDemographicsService _demographicsService;

        public PatientController(IUserService userService, IAddressService addressService,
            IPatientService patientService, IDemographicsService demographicsService) : base(userService)
        {
            _addressService = addressService;
            _patientService = patientService;
            _demographicsService = demographicsService;
        }

        public ActionResult Index()
        {
            var model = new UserModel();

            var patients = _patientService.GetAllPatients();
            model.Patients = patients;
            ViewBag.Success = TempData["Success"];

            return View(model);
        }

        public ActionResult View(long id)
        {
            var user = UserService.GetById(id);
            var model = new UserModel(user);

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new UserModel();
            var enumList = new List<SelectListItem>();
            enumList.Add(new SelectListItem {Text = "060"});
            enumList.Add(new SelectListItem {Text = "074"});
            enumList.Add(new SelectListItem {Text = "084"});
            enumList.Add(new SelectListItem {Text = "083"});
            enumList.Add(new SelectListItem {Text = "073"});
            enumList.Add(new SelectListItem {Text = "081"});
            enumList.Add(new SelectListItem {Text = "063"});
            enumList.Add(new SelectListItem {Text = "071"});
            enumList.Add(new SelectListItem {Text = "079"});
            enumList.Add(new SelectListItem {Text = "061"});
            enumList.Add(new SelectListItem {Text = "072"});
            enumList.Add(new SelectListItem {Text = "078"});

            model.NetworkCodes = enumList.ToList();

            return View(model);
        }

        public MapPoint GetLatitudeLongitude(string address)
        {
            var service = new GoogleLocationService("AIzaSyCkJcGWSqlARduCa__1aEg4MPmfaoylQN0");
            var mapPoint = service.GetLatLongFromAddress(address);

            return mapPoint;
        }
        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            var line1 = model.Address.Line1;
            var line2 = model.Address.Line2;

            var latLong = GetLatitudeLongitude(line1 + "," + line2);

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
                Status = EntityStatus.Active,
                RoleType = RoleType.Patient,
                Gender = model.Gender
            };
            UserService.SaveOrUpdate(user);

            var demographics = new Demography
            {
                StandNumber = model.Patient.Demography.StandNumber,
                Code = model.Patient.Demography.Code,
                Longitude = longitude,
                Latitude = latitude
            };

            _demographicsService.SaveOrUpdate(demographics);

            var patient = new Patient
            {
                Age = model.Patient.Age,
                IsMedicalAid = model.Patient.IsMedicalAid,
                Gender = model.Patient.Gender,
                ICD = model.Patient.ICD
            };

            patient.SetDemographics(demographics);
            patient.SetUsers(user);

            _patientService.SaveOrUpdate(patient);

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

            user.SetPatient(patient);
            user.SetAddress(address);
            UserService.SaveOrUpdate(user);

            var path = string.Format("{0}PatientEmail.txt", ConfigurationManager.AppSettings["email_templates_path"]);

            UserService.SetupEmail(user, path);
            TempData["Success"] = true;

            return RedirectToAction("Index");
        }
        public ActionResult Edit(long id)
        {
            var user = UserService.GetById(id);
            var model = new UserModel(user);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            var user = UserService.GetById(model.Id);
            user.Update(model);
            UserService.SaveOrUpdate(user);

            var address = _addressService.GetUserAddressById(model.Address.Id) ?? new Address {User = user};

            var addressModel = new AddressModel(model.Address);
            var patient = _patientService.GetPatientById(model.Patient.Id) ?? new Patient {User = user};
            var patientModel = new PatientModel(model.Patient);
            var demographics = _demographicsService.GetById(model.Patient.Demography.Id) ?? new Demography();
            var demographicsModel = new DemographicsModel(model.Patient.Demography);


            demographics.Update(demographicsModel);
            _demographicsService.SaveOrUpdate(demographics);
            patient.Update(patientModel);

            address.Update(addressModel);
            _addressService.SaveOrUpdate(address);

            patient.SetDemographics(demographics);
            _patientService.SaveOrUpdate(patient);

            user.SetAddress(address);
            user.SetPatient(patient);

            user.Update(model);
            UserService.SaveOrUpdate(user);

            return RedirectToAction("Index");
        }
    }
}