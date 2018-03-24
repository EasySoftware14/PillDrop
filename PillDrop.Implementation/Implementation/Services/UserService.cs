using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web;
using PillDrop.Domain.Contracts.Repositories;
using PillDrop.Domain.Contracts.Services;
using PillDrop.Domain.Entities;
using PillDrop.Implementation.Implementation.Helpers;

namespace PillDrop.Implementation.Implementation.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailArchiveService _emailArchiveService;
        private readonly IEmailNotificationService  _emailNotificationService;

        public UserService(IUserRepository userRepository, IEmailArchiveService emailArchiveService, IEmailNotificationService emailNotificationService)
        {
            _userRepository = userRepository;
            _emailArchiveService = emailArchiveService;
            _emailNotificationService = emailNotificationService;
        }
        public User GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }
        public void SetupEmail(User user, string path)
        {
            SendEmail(user, path);
        }
        private void SendEmail(User user, string path)
        {
            var args = Encription.GenerateEncryptionForEmail(user.Email);
            var pass = ConfigurationManager.AppSettings["EmailPassword"];
            var siteUrl = ConfigurationManager.AppSettings["local_website_url"];
            var sender = ConfigurationManager.AppSettings["sender"]; ;
            var mail = new MailMessage(sender, user.Email);
            var footerImage = $"{siteUrl}img/pilldrop.jpg";
           
            var link = string.Format("<a href='{0}user/setuppassword?token={1}'>Reset</a>", siteUrl, HttpUtility.UrlEncode(args));

            var templateToken = new TokenTemplate(path);
            templateToken.SetTokenValue("USER", user.Name);
            templateToken.SetTokenValue("NAME", user.GetRoleString());
            templateToken.SetTokenValue("DATE", user.CreatedAt.ToShortDateString());
            templateToken.SetTokenValue("LINK", link);
            templateToken.SetTokenValue("FOOTERIMAGE", footerImage);
            templateToken.SetTokenValue("ADMINEMAIL", user.Email);
            
            mail.To.Add(user.Email);
            mail.From = new MailAddress(sender, "PillDrop System");
            mail.Body = templateToken.Body;
            mail.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                smtp.EnableSsl = true;

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(sender, pass);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mail);

            }


            //var email = EmailMessage.CreateInstance(mail.From, user.Email, "PillDropper Registration", mail.Body);
            //_emailNotificationService.Send(email);

            //using (var smtp = new SmtpClient("mail.pilldropdev.co.za"))
            //{
            //    smtp.Credentials = new NetworkCredential(sender, pass);
            //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    smtp.Send(mail);
            //}
        }
        public long Save(User user)
        {
            using (var trans = _userRepository.Session.BeginTransaction())
            {
                var id = _userRepository.Save(user);
                trans.Commit();
                return id;
            }
        }
        public User GetUserForPasswordSetup(string email)
        {
            return _userRepository.GetUserForPasswordSetup(email);
        }
        public void SetupEmail(User user, string handler, string culture, string timezone)
        {
            var email = new EmailArchive()
            {
                ObjectId = user.Id,
                Recipients = user.Email,
                Handler = handler,
                Culture = culture,
                Timezone = timezone
            };
            _emailArchiveService.SaveOrUpdate(email);
        }
        public User GetById(long id)
        {
            return _userRepository.Get(id);
        }

        public IList<User> GetUsersByRoleType(RoleType type)
        {
            return _userRepository.GetUsersByRoleType(type);
        }

        public IList<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void SaveOrUpdate(User user)
        {
            using (var trans = _userRepository.Session.BeginTransaction())
            {
                _userRepository.SaveOrUpdate(user);
                trans.Commit();
            }
        }
    }
}