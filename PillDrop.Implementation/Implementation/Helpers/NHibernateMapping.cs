using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Burrow;
using NHibernate.Cfg;
using NHibernate.Event;
using PillDrop.Implementation.Persistence;

namespace PillDrop.Implementation.Implementation.Helpers
{
    public class NHibernateMapping : IConfigurator
    {

        public ISessionFactory SessionFactory;

        public void Config(IBurrowConfig val)
        {
            val.ManualTransactionManagement = true;
        }

        public void Config(IPersistenceUnitCfg puCfg, Configuration nhCfg)
        {
            var config = Fluently.Configure(nhCfg)
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromAppSetting("connection_string")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                .ExposeConfiguration(x => x.SetProperty("current_session_context_class", "web"))
                .ExposeConfiguration(x => x.SetProperty("connection.isolation", "ReadUncommitted"))
                .ExposeConfiguration(x => x.SetProperty("command_timeout", "60"))
                .ExposeConfiguration(x => x.SetProperty("show_sql", "false"))
                .ExposeConfiguration(x => x.SetProperty("adonet.batch_size", "1250"))
                .ExposeConfiguration(x => x.SetProperty("generate_statistics", "false"))
                .BuildConfiguration();
            config.EventListeners.PreInsertEventListeners = new IPreInsertEventListener[] { AuditTrailListener.Instance };
            config.EventListeners.PreUpdateEventListeners = new IPreUpdateEventListener[] { AuditTrailListener.Instance };
            SessionFactory = config.BuildSessionFactory();
            SessionFactory.Statistics.IsStatisticsEnabled = false;
        }
    }
}