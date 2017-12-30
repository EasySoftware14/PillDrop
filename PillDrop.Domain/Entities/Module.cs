using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillDrop.Domain.Entities
{
    public class Module : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Controller { get; set; }
        public virtual string Action { get; set; }
        public virtual int Order { get; set; }
        public virtual Module ParentModule { get; set; }
        public virtual IList<Module> SubModules { get; set; }
        public virtual IList<Feature> Features { get; set; }
        public virtual EntityStatus Status { get; set; }
        public virtual string UserTypes { get; set; }

        public Module()
        {
            Features = new List<Feature>();
            SubModules = new List<Module>();
        }

        public virtual void AddFeature(Feature feature)
        {
            Features.Add(feature);
        }
    }
}
