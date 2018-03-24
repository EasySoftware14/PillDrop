using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;
using PillDropApplication.Models;

namespace PillDropApplication.Controllers
{
    public class MedicalController : BaseController
    {
        private readonly IMedicalService _medicalService;
        private readonly IPrescriptionService _prescriptionService;
        private readonly IUserPrescriptionService _userPrescriptionService;
        private readonly IEmailArchiveService _emailArchiveService;

        public MedicalController(IUserService userService, IMedicalService medicalService,
            IPrescriptionService prescriptionService, IUserPrescriptionService userPrescriptionService, IEmailArchiveService emailArchiveService) : base(
            userService)
        {
            _medicalService = medicalService;
            _prescriptionService = prescriptionService;
            _userPrescriptionService = userPrescriptionService;
            _emailArchiveService = emailArchiveService;
        }

        public ActionResult Index()
        {
            var model = new UserPrescriptionModel();
            var userPrescriptionList = _userPrescriptionService.GetAllUserPrescriptions();
            var list = Convert.ToString(userPrescriptionList.Select(x => x.DateOfCollection));
            //model.ListOfCollectionDate = userPrescriptionList.Select(x => x.DateOfCollection).ToString().ToList();
            model.UserPrescriptions = userPrescriptionList;
            model.DateCollectionSet = "Not set";

            return View(model);
        }

        public ActionResult Assign()
        {
            var model = new MedicalModel();
            var users = UserService.GetUsersByRoleType(RoleType.Patient);
            var prescriptions = _prescriptionService.Prescriptions();

            model.Users = users.Select(
                user =>
                    new SelectListItem()
                    {
                        Selected = false,
                        Text = user.Name,
                        Value = user.Id.ToString()
                    }).ToList();

            model.Prescriptions = prescriptions.Select(x => new PrescriptionModel(x)).OrderBy(x => x.Name).ToList();

            return View(model);
        }

        public ActionResult SetCollection(long id)
        {
            var prescription = _userPrescriptionService.GetUserPrescriptionById(id);
            var presIds = prescription.Prescription.Split(',');
            var prescriptionList = new List<Prescription>();

            foreach (var presId in presIds)
            {
                prescriptionList.Add(_prescriptionService.GetPrescriptionById(Convert.ToInt64(presId)));
            }

            var prescriptions = _prescriptionService.Prescriptions();
            var model = new UserPrescriptionModel(prescription);
            model.SelectedPrescriptions = prescriptionList;
            model.FullName = prescription.User.Name + " " + prescription.User.Surname;
            model.Prescriptions = prescriptions.Select(x => new PrescriptionModel(x)).OrderBy(x => x.Name).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assign(MedicalModel model)
        {
            var user = UserService.GetById(model.UserId);
            
            var loggedInuser = (User)Session["User"];
            var dateOfCollection = Convert.ToDateTime(model.DateCollected);
            var userPrep = new UserPrescription
            {
                User = user,
                AssignedByUser = loggedInuser,
                DateOfCollection = dateOfCollection,
                Prescription = model.MedicineIds,
                Collected = false,

            };
            _userPrescriptionService.SaveOrUpdate(userPrep);

            var emailArchieve = new EmailArchive
            {
                ObjectId = userPrep.Id,
                Handler = "MedicineAssign",
                IsSent = false
            };
            _emailArchiveService.SaveOrUpdate(emailArchieve);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SetCollection(UserPrescriptionModel model)
        {
            var userPresc = _userPrescriptionService.GetUserPrescriptionById(model.Id);
            userPresc.DateOfCollection = model.DateOfCollection;

            _userPrescriptionService.SaveOrUpdate(userPresc);

            return RedirectToAction("Index");

        }
    }
}