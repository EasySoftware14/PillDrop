using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillDrop.Domain.Entities
{
    public class RoleModule
    {
        public virtual Role Role { get; set; }
        public virtual Module Module { get; set; }
        public virtual Module SubModule { get; set; }
    }
}
