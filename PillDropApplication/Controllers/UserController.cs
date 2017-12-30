using System.Linq;
using System.Web.Mvc;
using NHibernate.Linq;
using PillDrop.Domain;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;
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

        public UserController(IUserService userService, IPatientService patientService,
            IPillDropperService pillDropperService, IRecoveryQuestionService recoveryQuestionService, 
            IAuthenticationService authenticationService, IDemographicsService demographicsService) : base(userService)
        {
            _pillDropperService = pillDropperService;
            _patientService = patientService;
            _recoveryQuestionService = recoveryQuestionService;
            _authenticationService = authenticationService;
            _demographicsService = demographicsService;
        }

        public ActionResult Index()
        {
            var users = UserService.GetAllUsers();
            var model = new UserModel();

            model.Users = users;

            return View(model);
        }
        public ActionResult View(long id)
        {

            return View(" ");
        }
        public ActionResult Edit(long id)
        {

            return View(" ");
        }
        public ActionResult Delete(long id)
        {

            return View(" ");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserModel model)
        {

            return View(" ");
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
            model.RoleList = GetRoleList();

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
            var models = model;
           
            //user.
            //_userService.SaveOrUpdate();
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
                Location = model.Patient.Demography.Location

            };
            _demographicsService.SaveOrUpdate(demographics);

            var patient = new Patient
            {
                Age = model.Patient.Age,
                IsMedicalAid = model.Patient.IsMedicalAid,
                User = user,
                Gender = model.Patient.Gender,
                Demography = demographics,
                ICD = model.Patient.ICD
            };
            
            _patientService.SaveOrUpdate(patient);

            UserService.SetupEmail(user);

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
                Status = EntityStatus.InActive,
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

            _pillDropperService.SaveOrUpdate(pillDropper);
            UserService.SetupEmail(user);

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