using Raven.Client.Documents;

namespace Expensely.Application.Documents
{
    public interface IDocumentStoreProvider
    {
        IDocumentStore GetDocumentStore();
    }
}