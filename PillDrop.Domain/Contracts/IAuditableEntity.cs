using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillDrop.Domain.Contracts
{
    public interface IAuditableEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime ModifiedAt { get; set; }
        bool Audited { get; set; }
    }
}
