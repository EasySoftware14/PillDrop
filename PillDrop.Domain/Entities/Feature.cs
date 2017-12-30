using System.Collections.Generic;

namespace PillDrop.Domain.Entities
{
    public class Feature
    {
        public virtual string Name { get; set; }
        public virtual Module Module { get; set; }
        public virtual IList<Module> Modules { get; set; }
        public virtual SubModule SubModule { get; set; }
        public virtual string UserTypes { get; set; }
    }
}
