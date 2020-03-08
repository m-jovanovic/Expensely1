using Raven.Client.Documents.Session;

namespace Expensely.Infrastructure.Persistence.Events.OnAfterConversionToEntity
{
    internal interface IOnAfterConversionToEntityEvent
    {
        void Handle(object? sender, AfterConversionToEntityEventArgs args);
    }
}
