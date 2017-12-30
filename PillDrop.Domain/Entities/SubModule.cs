using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillDrop.Domain.Entities
{
    public class SubModule
    {
        public virtual string Name { get; set; }
        public virtual string Controller { get; set; }
        public virtual string Action { get; set; }
        public virtual int Order { get; set; }
        public virtual Module ParentModule { get; set; }
        public virtual IList<Module> Modules { get; set; }
        public virtual IList<Feature> Features { get; set; }
        public virtual IList<SubModule> SubModules { get; set; }
        public virtual EntityStatus Status { get; set; }
        public virtual string UserTypes { get; set; }

        public SubModule()
        {
            Modules = new List<Module>();
            Features = new List<Feature>();
            SubModules = new List<SubModule>();
        }

        public virtual void AddFeature(Feature feature)
        {
            Features.Add(feature);
        }

        public virtual void AddSubModules(Module subModule)
        {
            Modules.Add(subModule);
        }
    }
}
