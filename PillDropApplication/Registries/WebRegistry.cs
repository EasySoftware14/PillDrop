using log4net;
using StructureMap.Configuration.DSL;

namespace PillDropApplication.Registries
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            For<ILog>().Singleton().Use(MvcApplication.Log);
        }
    }
}