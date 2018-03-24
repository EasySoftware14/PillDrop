using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillDrop.Domain.Entities
{
    public enum RoleType
    {
        [Description ("Administrator")]
        PillDropAdmin = 0,
        [Description("HeathCare Pesonnel")]
        HealthCarePersonnel,
        PillDropper,
        Patient
    }
}
