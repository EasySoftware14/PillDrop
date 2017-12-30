using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PillDropApplication.Registries;
using StructureMap;

namespace PillDropApplication
{
    public class StructureMapBootStrapper
    {
        private static bool _hasStarted;

        public virtual void BootstrapStructureMap()
        {
            ObjectFactory.Initialize(x =>
                x.Scan(s =>
                    {
                        s.TheCallingAssembly();
                        s.AssemblyContainingType<ServiceRegistry>();
                        s.AssemblyContainingType<NHibernateRegistry>();
                        s.LookForRegistries();
                    }
                )
            );
        }

        public static void Restart()
        {
            if (_hasStarted)
            {
                ObjectFactory.ResetDefaults();
            }
            else
            {
                Bootstrap();
                _hasStarted = true;
            }
        }

        public static void Bootstrap()
        {
            new StructureMapBootStrapper().BootstrapStructureMap();
        }
    }
}