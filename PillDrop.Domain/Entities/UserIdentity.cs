using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Newtonsoft.Json;

namespace PillDrop.Domain.Entities
{
    public class UserIdentity : IIdentity
    {
        public string Name { get; }
        public string AuthenticationType { get; }
        public long Id { get; private set; }
        public string FullUserName { get; set; }
        public bool RememberMe { get; private set; }
        public bool IsAdmin { get; set; }
        public bool IsAuthenticated
        {
            get { return Id > 0; }
        }

        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<string> Features { get; set; }
        public string HubName { get; set; }
        public string TimeZoneid { get; set; }
        public string OrgType { get; set; }


        public UserIdentity(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                return;
            var data = JsonConvert.DeserializeObject<PillDropCookie>(ticket.UserData);
            Id = data.Id;
            Name = data.Name;
            FullUserName = data.FullUserName;
            HubName = data.HubName;
            RememberMe = data.RememberMe;
            Roles = data.Roles ?? new List<string>();
            Features = data.Features ?? new List<string>();
            IsAdmin = data.IsAdmin;
        }
    }
}
