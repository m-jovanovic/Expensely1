using System;
using System.Reflection;
using Expensely.Domain;
using Raven.Client.Documents.Session;

namespace Expensely.Infrastructure.Persistence.Events.OnBeforeStore
{
    internal sealed class SetAuditableEntityValues : IOnBeforeStoreEvent
    {
        public void Handle(object? sender, BeforeStoreEventArgs args)
        {
            if (!(args.Entity is IAuditableEntity auditableEntity))
            {
                return;
            }

            PropertyInfo? propertyInfo = auditableEntity.GetType().GetProperty(nameof(IAuditableEntity.CreatedOnUtc));

            propertyInfo?.SetValue(auditableEntity, DateTime.UtcNow);

            // TODO: Determine when to set modified on date.
        }
    }
}