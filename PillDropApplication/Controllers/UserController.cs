using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using NHibernate.Linq;
using PillDrop.Domain;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;
using PillDrop.Domain.Extensions;
using PillDrop.Domain.Presentation;
using PillDrop.Implementation.Implementation;
using PillDropApplication.Models;

namespace PillDropApplication.Controllers
{
    public class UserController : BaseController
    {
        private readonly IPatientService _patientService;
        private readonly IPillDropperService _pillDropperService;
        private readonly IRecoveryQuestionService _recoveryQuestionService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IDemographicsService _demographicsService;
        private readonly IAddressService _addressService;
        private readonly IOrganizationService _organizationService;

        public UserController(IUserService userService, IPatientService patientService,
            IPillDropperService pillDropperService, IRecoveryQuestionService recoveryQuestionService, 
            IAuthenticationService authenticationService, IDemographicsService demographicsService, IAddressService addressService,
            IOrganizationService organizationService) : base(userService)
        {
            _pillDropperService = pillDropperService;
            _patientService = patientService;
            _recoveryQuestionService = recoveryQuestionService;
            _authenticationService = authenticationService;
            _demographicsService = demographicsService;
            _addressService = addressService;
            _organizationService = organizationService;
        }

        public ActionResult Index()
        {
            var users = UserService.GetAllUsers();
            var model = new UserModel();

            model.Users = users.OrderByDescending(x => x.ModifiedAt).ToList();

            return View(model);
        }
        public ActionResult View(long id)
        {
            var user = UserService.GetById(id);
            var userModel = new UserModel(user);

            if (user.RoleType.Equals(RoleType.Patient))
            {
                return View("ViewPatient", userModel);
            }
            if (user.RoleType.Equals(RoleType.PillDropper))
            {
                return View("View", userModel);
            }

            return View(" ");
            
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var user = UserService.GetById(id);
            var userModel = new UserModel(user);

            if (user.RoleType.Equals(RoleType.Patient))
            {
                return View("EditPatient", userModel);
            }
            if (user.RoleType.Equals(RoleType.PillDropper))
            {
                return View("EditPillDropper", userModel);
            }

            return View(" ");
        }
       
        public ActionResult Delete(long id)
        {
            var user = UserService.GetById(id);
            user.Status = EntityStatus.InActive;
            UserService.SaveOrUpdate(user);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPatient(UserModel model)
        {
            var user = UserService.GetById(model.Id);
            user.Update(model);
            UserService.SaveOrUpdate(user);

            var address = _addressService.GetUserAddressById(model.Address.Id) ?? new Address{ User = user};

            var addressModel = new AddressModel(model.Address);
            var patient = _patientService.GetPatientById(model.Patient.Id) ?? new Patient { User = user};
            var patientModel = new PatientModel(model.Patient);
            var demographics = _demographicsService.GetById(model.Patient.Demography.Id) ??  new Demography();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPillDropper(UserModel model)
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
        public ActionResult ListAjaxHandler()
        {
            var users = UserService.GetAllUsers();
            var userCount = users.Count;

            var paginate = new PaginateModel
            {
                //sEcho = model.sEcho,
                iTotalRecords = userCount,
                iTotalDisplayRecords = userCount,
                aaData = users.Select(x => new[]
                {
                    x.Name,
                    x.Surname,
                    x.Number,
                    x.RoleType.ToString(),
                    x.Status.ToString(),
                    x.Id.ToString()
                }).ToList()
            };

            return Json(paginate, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ForgotPassword()
        {
            return View("Index");
        }

        public ActionResult Create()
        {
            var model = new UserModel();
            //var organizationList = _organizationService.GetOrganizations();
            model.RoleList = GetRoleList();
            var list = Enum.GetValues(typeof(RoleType)).Cast<RoleType>();
            model.OrganizationList = list.Select(item => new SelectListItem { Selected = false, Text = item.GetEnumDescription(),
                Value = item.ToString() }).ToList();
           
            return View(model);
        }
        public ActionResult Patient()
        {
            var model = new UserModel();
            model.RoleList = GetRoleList();

            return View("Partial/_Patient");
        }
        public ActionResult PillDropper()
        {
            var model = new UserModel();
            model.RoleList = GetRoleList();

            return View("Partial/_PillDropper");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserModel model)
        {
          
            var user = new User
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Number = model.Number,
                Status = EntityStatus.Active,
                RoleType = RoleType.Patient,
                
            };

            UserService.SaveOrUpdate(user);

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Patient(UserModel model)
        {
            
            var user = new User
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Number = model.Number,
                Status = EntityStatus.Active,
                RoleType = RoleType.Patient

            };
            UserService.SaveOrUpdate(user);
       
            var demographics = new Demography
            {
                StandNumber = model.Patient.Demography.StandNumber,
                Code = model.Patient.Demography.Code,
                Gps = model.Patient.Demography.Gps,
                
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

            var path = string.Format("{0}Registration.txt", ConfigurationManager.AppSettings["email_templates_path"]);

            UserService.SetupEmail(user, path);

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PillDropper(UserModel model)
        {
            var user = new User
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Number = model.Number,
                Status = EntityStatus.Active,
                RoleType = RoleType.PillDropper

            };
            UserService.SaveOrUpdate(user);

            var pillDropper = new PillDropper
            {
                LicencePlateNumber = model.PillDropper.LicencePlateNumber,
                LicenceNumber = model.PillDropper.LicenceNumber,
                User = user,
                VetteCertificate = model.PillDropper.VetteCertificate
                 
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

            var path = string.Format("{0}Registration.txt", ConfigurationManager.AppSettings["email_templates_path"]);

            UserService.SetupEmail(user, path);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult SetupPassword(string token)
        {
            var decryptedEmail = Encription.GenerateDecryption(token);
            var splitter = decryptedEmail.Split('$');
            var questions = _recoveryQuestionService.GetQuestions();

            decryptedEmail = splitter[0];
            var user = UserService.GetByEmail(decryptedEmail);
            var model = new PasswordSetupModel { UserName = user.Email };
            model.RecoveryQuestions = questions;

            return View(model);
        }
        [ValidateAntiForgeryToken]
        [ HttpPost]
        public ActionResult SetupPassword(PasswordSetupModel model)
        {
            var user = UserService.GetUserForPasswordSetup(model.UserName);
            var password = _authenticationService.GetPasswordHash(model.UserName, model.Password);

            user.SetStatus(EntityStatus.Active);
            user.SetHashedPassword(password);

            var recoveryQuestion = _recoveryQuestionService.GetQuestionById(model.RecoveryQuestionId);
            user.SetRecoveryQuestion(recoveryQuestion);

            var currentRecoveryQuestionAnswer = _authenticationService.GetPasswordHash(recoveryQuestion.Question, model.SecurityAnswer);
            user.SetHashedRecoveryAnswer(currentRecoveryQuestionAnswer);
            user.RecoveryQuestion.Id = model.RecoveryQuestionId;

            UserService.SaveOrUpdate(user);
            TempData["success"] = true;

            return RedirectToAction("login", "auth");
        }
    }
}