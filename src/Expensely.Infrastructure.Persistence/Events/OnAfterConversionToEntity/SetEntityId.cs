using System.Reflection;
using Expensely.Domain;
using Raven.Client.Documents.Session;

namespace Expensely.Infrastructure.Persistence.Events.OnAfterConversionToEntity
{
    internal sealed class SetEntityId : IOnAfterConversionToEntityEvent
    {
        public void Handle(object? sender, AfterConversionToEntityEventArgs args)
        {
            if (!(args.Entity is Entity entity))
            {
                return;
            }

            PropertyInfo? propertyInfo = entity.GetType().GetProperty(nameof(Entity.Id));

            propertyInfo?.SetValue(entity, args.Id);
        }
    }
}