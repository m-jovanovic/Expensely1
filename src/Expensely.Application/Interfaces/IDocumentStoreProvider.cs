using Raven.Client.Documents;

namespace Expensely.Application.Interfaces
{
    public interface IDocumentStoreProvider
    {
        IDocumentStore GetDocumentStore();
    }
}