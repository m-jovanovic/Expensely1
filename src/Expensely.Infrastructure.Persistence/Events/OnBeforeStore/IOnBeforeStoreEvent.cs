using Raven.Client.Documents.Session;

namespace Expensely.Infrastructure.Persistence.Events.OnBeforeStore
{
    internal interface IOnBeforeStoreEvent
    {
        void Handle(object? sender, BeforeStoreEventArgs args);
    }
}
