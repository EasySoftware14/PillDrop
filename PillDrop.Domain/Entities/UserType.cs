using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillDrop.Domain.Entities
{
    public class UserType
    {
        public virtual string Name { get; set; }
        public virtual EntityStatus Status { get; set; }
        public virtual RoleType Type { get; set; }
        public virtual Role Role { get; set; }
        public virtual string OrganizationType { get; set; }
        public virtual AccessType AccessType { get; set; }
    }
}
