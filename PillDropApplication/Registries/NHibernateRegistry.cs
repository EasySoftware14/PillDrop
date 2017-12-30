using NHibernate;
using PillDrop.Implementation.Implementation.Helpers;
using StructureMap.Configuration.DSL;

namespace PillDropApplication.Registries
{
    public class NHibernateRegistry : Registry
    {
        public NHibernateRegistry()
        {
            For<ISession>().HybridHttpOrThreadLocalScoped().Use(ctx => NHibernateHelper.GetCurrentSession());
        }
    }
}