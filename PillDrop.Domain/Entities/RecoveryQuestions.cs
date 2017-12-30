using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillDrop.Domain.Contracts;
using PillDrop.Domain.Contracts.Models;

namespace PillDrop.Domain.Entities
{
    public class RecoveryQuestion : Entity
    {
        public virtual string Question { get; set; }
        public virtual EntityStatus Status { get; set; }
        public RecoveryQuestion()
        {

        }
        public virtual void Update(IRecoveryQuestionModel recovery)
        {
            Question = recovery.Question;
            Status = recovery.Status;
        }
    }
}
