using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PillDrop.Domain.Contracts;

namespace PillDrop.Implementation.Implementation.Helpers
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string GetSetting(string key)
        {
            if (ConfigurationManager.AppSettings[key] == null)
                throw new Exception(string.Format("Please set configuration key {0}. Key not found", key));
            return ConfigurationManager.AppSettings[key];
        }
    }
}
