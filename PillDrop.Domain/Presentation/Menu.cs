using System.Collections.Generic;
using PillDrop.Domain.Entities;

namespace PillDrop.Domain.Presentation
{
    public class Menu
    {
        public long ModuleId { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Roles { get; set; }
        public int Order { get; set; }
        public IList<Menu> SubMenu { get; set; }

        public Menu()
        {
            SubMenu = new List<Menu>();
        }

        public Menu(Module module)
        {
            ModuleId = module.Id;
            Name = module.Name;
            Controller = module.Controller;
            Action = module.Action;
            Order = module.Order;
        }
    }
}
