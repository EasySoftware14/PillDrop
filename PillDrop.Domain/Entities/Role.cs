using System.Collections.Generic;
using System.Linq;

namespace PillDrop.Domain.Entities
{
    public class Role : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<RoleModule> RoleModules { get; set; }
        public virtual IList<RoleSubModule> RoleSubModules { get; set; }
        public virtual IList<SubModule> SubModule { get; set; }
        public virtual IList<RoleFeature> RoleFeatures { get; set; }
        public virtual EntityStatus Status { get; set; }
        public virtual UserType UserType { get; set; }

        public Role()
        {
            RoleModules = new List<RoleModule>();
            RoleFeatures = new List<RoleFeature>();
            SubModule = new List<SubModule>();
            RoleSubModules = new List<RoleSubModule>();
        }

        public virtual void AddModule(Module module)
        {
            RoleModules.Add(new RoleModule() { Role = this, Module = module });
        }
        public virtual IList<Module> GetSubModules()
        {
            return RoleSubModules.Select(x => x.SubModule).ToList();
        }
    }
}
