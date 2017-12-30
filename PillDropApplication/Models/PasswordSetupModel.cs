using System.Collections.Generic;
using PillDrop.Domain.Entities;

namespace PillDropApplication.Models
{
    public class PasswordSetupModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SecurityAnswer { get; set; }
        public long RecoveryQuestionId { get; set; }
        public IList<RecoveryQuestion> RecoveryQuestions { get; set; }

        public PasswordSetupModel()
        {
            RecoveryQuestions = new List<RecoveryQuestion>();
        }
    }
}