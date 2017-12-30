using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Implementation.Implementation;
using PillDropApplication.Models;

namespace PillDropApplication.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IApplicationConfiguration _applicationConfiguration;
        private readonly IAuthenticationService _authenticationService;
        private readonly IRecoveryQuestionService _recoveryQuestionService;
        private readonly IUserService _userService;

        public AuthController(IApplicationConfiguration applicationConfiguration, IUserService userService, IAuthenticationService authenticationService, IRecoveryQuestionService recoveryQuestionService) : base(userService)
        {
            _applicationConfiguration = applicationConfiguration;
            _authenticationService = authenticationService;
            _recoveryQuestionService = recoveryQuestionService;
            _userService = userService;
        }
        // GET: Auth
        public ActionResult Login(string returnUrl)
        {
            string temppasswordquery = Request.QueryString["temppassword"];

            if (User.Identity.IsAuthenticated)
            {
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);

                return Redirect("/home");
            }

            if (temppasswordquery != null)
            {
                TempData["TempFromEmail"] = true;
            }

            var timeout = Convert.ToInt32(_applicationConfiguration.GetSetting("default_language_persistance_timeout"));
            //CreateCultureCookie(timeout);
            var model = new LoginModel { ReturnUrl = returnUrl, TempPassword = temppasswordquery };
            ViewBag.tempPassword = temppasswordquery;
            ViewBag.Success = TempData["success"];

            ClearSessionVariables();

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        var user = _authenticationService.Validate(loginModel.UserName, loginModel.Password);

            //        if (!string.IsNullOrEmpty(user.TemporaryPassword))
            //        {
            //            var partialviewstring = user.RecoveryQuestion != null ? "Partial/_ResetPassword" : "Partial/_ResetPasswordFirstTime";
            //            user.TemporaryPassword = null;
            //            loginModel.RecoveryQuestion = user.RecoveryQuestion;
            //            loginModel.RecoveryQuestionAnswer = user.RecoveryQuestionAnswer;
            //            var recoveryQuestions = _recoveryQuestionService.GetQuestions();
            //            loginModel.RecoveryQuestions = recoveryQuestions;
            //            UserService.SaveOrUpdate(user);
            //            TempData["Success"] = true;

            //            return View(partialviewstring, loginModel);
            //        }

            //        var cookie = Request.Cookies["_culture"];

            //        if (loginModel.PersistCulture)
            //        {
            //            if (cookie == null)
            //                return RedirectToAction("login");

            //            cookie.Values.Set("persisted", "1");
            //            Response.AppendCookie(cookie);
            //        }
            //        //else
            //        //{
            //        //    SetCookieValue(cookie, "persisted", "0");
            //        //}

            //        //var httpCookie = GenerateIdentityCookie(loginModel, user);
            //        //Response.Cookies.Add(httpCookie);

            //        return !string.IsNullOrEmpty(loginModel.ReturnUrl)
            //            ? Redirect(loginModel.ReturnUrl)
            //            : (ActionResult)RedirectToAction("index", "home");
            //    }
            //    catch (Exception e)
            //    {
            //        loginModel.ExceptionMessage = e.Message;

            //        return View(loginModel);
            //    }
            //}

            return RedirectToAction("index","Home");
        }

        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            try
            {
                var user = UserService.GetByEmail(email);

                if (user != null)
                {
                    user.ResetPassword();
                    UserService.SaveOrUpdate(user);
                    const string description = "Password reset email sent.";

                    return Json(new { Success = true, Description = description });
                }

                throw new Exception("The email specified is not registered.");
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Description = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult ResetPassword(string email)
        {
            var decrypted = Encription.GenerateDecryption(email);
            var splitter = decrypted.Split('$');
            var decryptedEmail = splitter[0];
            ViewBag.userEmailAdress = decryptedEmail;

            DateTime decryptedDate = Convert.ToDateTime(splitter[1]);
            TimeSpan difference = DateTime.Now.Subtract(decryptedDate);
            double hours = difference.TotalHours;

            if (hours > 1.00)
            {
                ViewBag.ExpiredLink = true;
            }

            var user = _userService.GetByEmail(decryptedEmail);

            return View(new LoginModel(user));
        }

        [HttpPost]
        public ActionResult ResetPassword(LoginModel model)
        {
            var user = _userService.GetByEmail(model.UserName);
            var status = "";
            if (model.Password == model.ConfirmPassword)
            {
                var currentrecoveryQuestion = _recoveryQuestionService.GetQuestionById(model.RecoveryQuestionId);
                var currentRecoveryQuestionAnswer = _authenticationService.GetPasswordHash(currentrecoveryQuestion.Question,
                                model.RecoveryQuestionAnswer);
                if (model.RecoveryAnswerCheck == currentRecoveryQuestionAnswer)
                {
                    var hashPassword = _authenticationService.GetPasswordHash(model.UserName, model.Password);
                    user.SetHashedPassword(hashPassword);
                    user.ResetTemporaryPassword();

                    if (model.DoYouWishToChangeRecoveryQuestion)
                    {
                        var recoveryQuestion = _recoveryQuestionService.GetQuestionById(model.RecoveryQuestionEdit);
                        var hashRecoveryQuestionEditAnswer =
                            _authenticationService.GetPasswordHash(recoveryQuestion.Question,
                                model.RecoveryQuestionEditAnswer);
                    }

                    _userService.SaveOrUpdate(user);
                    status = "true";
                }
                else
                {
                    ModelState.AddModelError("", "Your recovery question answer is wrong");
                    status = "securityquestionwrong";
                }
            }
            else
            {
                ModelState.AddModelError("", "Your password and temp password does not match");
                status = "passwordnotmatch";
            }

            TempData["Success"] = status;

            return RedirectToAction("login");
        }
        [HttpPost]
        public ActionResult ResetPasswordFirstTime(LoginModel model)
        {
            var user = _userService.GetByEmail(model.UserName);
            var status = "";

            if (model.Password == model.ConfirmPassword)
            {
                var hashPassword = _authenticationService.GetPasswordHash(model.UserName, model.Password);
                user.SetHashedPassword(hashPassword);
                user.ResetTemporaryPassword();

                var recoveryQuestion = _recoveryQuestionService.GetQuestionById(model.RecoveryQuestionEdit);
                var hashRecoveryQuestionEditAnswer =
                    _authenticationService.GetPasswordHash(recoveryQuestion.Question,
                        model.RecoveryQuestionEditAnswer);

                user.SetRecoveryQuestion(recoveryQuestion);
                user.SetHashedRecoveryAnswer(hashRecoveryQuestionEditAnswer);

                _userService.SaveOrUpdate(user);
                status = "true";
            }
            else
            {
                ModelState.AddModelError("", "Your password and temp password does not match");
                status = "passwordnotmatch";
            }

            TempData["Success"] = status;

            return RedirectToAction("login");
        }
    }
}