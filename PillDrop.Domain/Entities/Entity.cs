using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillDrop.Domain.Contracts;

namespace PillDrop.Domain.Entities
{
    public class Entity : IEntity, IAuditableEntity
    {
        public virtual long Id { get; set; }
        public virtual string Key { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime ModifiedAt { get; set; }
        public virtual bool Audited { get; set; }

        public virtual bool IsTransient()
        {
            return Id.Equals(default(long));
        }
    }
}
