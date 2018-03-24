using NHibernate;
using StructureMap.Configuration.DSL;
using NServiceBus.ObjectBuilder.StructureMap262;

namespace PillDrop.Implementation.Container
{
    public class NhibernateRegistry : Registry
    {
        public NhibernateRegistry()
        {
            For<ISession>().LifecycleIs(new NServiceBusThreadLocalStorageLifestyle()).Use(ctx => ctx.GetInstance<ISessionFactory>().OpenSession());
        }
    }
}