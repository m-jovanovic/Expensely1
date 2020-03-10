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

            PropertyInfo? createdOnUtcPropertyInfo =
                auditableEntity.GetType().GetProperty(nameof(IAuditableEntity.CreatedOnUtc))!;

            if (createdOnUtcPropertyInfo is null)
            {
                return;
            }

            var value = (DateTime)createdOnUtcPropertyInfo.GetValue(auditableEntity)!;

            if (value == default)
            {
                createdOnUtcPropertyInfo.SetValue(auditableEntity, DateTime.UtcNow);
            }
            else
            {
                PropertyInfo? modifiedOnUtcPropertyInfo =
                    auditableEntity.GetType().GetProperty(nameof(IAuditableEntity.ModifiedOnUtc));

                modifiedOnUtcPropertyInfo?.SetValue(auditableEntity, DateTime.UtcNow);
            }
        }
    }
}