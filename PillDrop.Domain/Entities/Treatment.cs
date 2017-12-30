using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillDrop.Domain.Entities
{
    public class Treatment : Entity
    {
        public virtual string Name { get; set; }

        public Treatment()
        {
            
        }
    }
}
