using System;
using Expensely.Application.Documents;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;

namespace Expensely.Infrastructure.Persistence
{
    internal sealed class DocumentStoreProvider : IDocumentStoreProvider, IDisposable
    {
        private readonly DocumentStore _documentStore;

        public DocumentStoreProvider(IOptions<RavenDbSettings> options)
        {
            RavenDbSettings ravenDbSettings = options.Value;

            _documentStore = new DocumentStore
            {
                Urls = ravenDbSettings.Urls,
                Database = ravenDbSettings.Database
            };

            _documentStore.Initialize();

            CreateDatabaseIfNotExists();
        }

        /// <inheritdoc />
        public IDocumentStore GetDocumentStore() => _documentStore;

        /// <inheritdoc />
        public void Dispose()
        {
            _documentStore?.Dispose();
        }

        /// <summary>
        /// Creates the database specified in the <see cref="IDocumentStore.Database"/> property if it doesn't exist.
        /// </summary>
        private void CreateDatabaseIfNotExists()
        {
            var getDatabaseRecordOperation = new GetDatabaseRecordOperation(_documentStore.Database);

            DatabaseRecordWithEtag databaseRecord = _documentStore.Maintenance.Server.Send(getDatabaseRecordOperation);

            if (databaseRecord != null)
            {
                return;
            }

            var createDatabaseOperation = new CreateDatabaseOperation(new DatabaseRecord(_documentStore.Database));

            _documentStore.Maintenance.Server.Send(createDatabaseOperation);
        }
    }
}
