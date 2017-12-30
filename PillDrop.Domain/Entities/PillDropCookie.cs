using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillDrop.Domain.Entities
{
    public class PillDropCookie
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string FullUserName { get; set; }
        public string Name { get; set; }
        public bool RememberMe { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<string> Features { get; set; }
        public string HubName { get; set; }
        public bool IsAdmin { get; set; }
       
    }
}
