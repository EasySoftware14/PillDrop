using System;
using System.Threading;
using System.Threading.Tasks;
using NHibernate.Event;
using NHibernate.Persister.Entity;
using PillDrop.Domain.Contracts;

namespace PillDrop.Implementation.Implementation.Helpers
{
    public class AuditTrailListener : IPreUpdateEventListener, IPreInsertEventListener
    {
        private static readonly Lazy<AuditTrailListener> Lazy = new Lazy<AuditTrailListener>(() => new AuditTrailListener());
        public static AuditTrailListener Instance { get { return Lazy.Value; } }

        private AuditTrailListener()
        {
        }

        public Task<bool> OnPreUpdateAsync(PreUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            var audit = @event.Entity as IAuditableEntity;
            if (audit == null)
                return false;

            var time = DateTime.Now;
            Set(@event.Persister, @event.State, "ModifiedAt", time);
            audit.ModifiedAt = time;

            return false;
        }


        public Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool OnPreInsert(PreInsertEvent @event)
        {
            var audit = @event.Entity as IAuditableEntity;
            if (audit == null)
                return false;

            var time = DateTime.Now;

            Set(@event.Persister, @event.State, "ModifiedAt", time);
            Set(@event.Persister, @event.State, "CreatedAt", time);
            audit.ModifiedAt = time;
            audit.CreatedAt = time;

            return false;
        }

        private void Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }
    }
}