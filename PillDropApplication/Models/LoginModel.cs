using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PillDrop.Domain.Entities;

namespace PillDropApplication.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string TempPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public bool UseTempPassword { get; set; }
        public bool PersistAuthentication { get; set; }
        public bool PersistCulture { get; set; }
        public string ReturnUrl { get; set; }
        public string ExceptionMessage { get; set; }
        public RecoveryQuestion RecoveryQuestion { get; set; }
        public int RecoveryQuestionId { get; set; }
        public string RecoveryQuestionAnswer { get; set; }
        public string RecoveryAnswerCheck { get; set; }
        public int RecoveryQuestionEdit { get; set; }
        public string RecoveryQuestionEditAnswer { get; set; }
        public bool DoYouWishToChangeRecoveryQuestion { get; set; }
        public IList<RecoveryQuestion> RecoveryQuestions { get; set; }

        public LoginModel()
        {

        }

        public LoginModel(User user)
        {
            UserName = user.Email;
            Password = user.PasswordHash;
            ConfirmPassword = user.PasswordHash;
            TempPassword = user.TemporaryPassword;
            RecoveryQuestion = user.RecoveryQuestion;
            RecoveryQuestionAnswer = user.RecoveryQuestionAnswer;
        }
    }
}