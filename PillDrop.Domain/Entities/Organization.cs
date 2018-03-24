using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillDrop.Domain.Contracts.Models;

namespace PillDrop.Domain.Entities
{
    public class Organization : Entity
    {
        public virtual string Name { get; set; }
        public virtual EntityStatus Status { get; set; }

        public Organization()
        {
            
        }

        public virtual void Update(IOrganizationModel model)
        {
            Name = model.Name;
        }
        public virtual void SetStatus(EntityStatus status)
        {
            Status = status;
        }
    }
}
