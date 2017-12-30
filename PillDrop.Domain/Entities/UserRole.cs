using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillDrop.Domain.Entities
{
    public class UserRole
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
