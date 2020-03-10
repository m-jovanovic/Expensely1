using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Expensely.Application.Interfaces;
using Expensely.Infrastructure.Persistence.Events.OnAfterConversionToEntity;
using Expensely.Infrastructure.Persistence.Events.OnBeforeStore;
using Raven.Client.Documents;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;

namespace Expensely.Infrastructure.Persistence
{
    internal sealed class DocumentStoreProvider : IDocumentStoreProvider, IDisposable
    {
        private readonly DocumentStore _documentStore;

        public DocumentStoreProvider(RavenDbSettings settings)
        {
            _documentStore = new DocumentStore
            {
                Urls = settings.Urls,
                Database = settings.Database
            };

            RegisterEvents();

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

        private static IEnumerable<T> GetAllImplementationsOf<T>(Assembly assembly)
            where T : class
        {
            Type typeOfInterface = typeof(T);

            IEnumerable<T> interfaceImplementations =
                from t in assembly.GetTypes()
                where typeOfInterface.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract
                select Activator.CreateInstance(t) as T;

            return interfaceImplementations;
        }

        private void RegisterEvents()
        {
            Type callingType = GetType();

            var assembly = Assembly.GetAssembly(callingType);

            if (assembly is null)
            {
                throw new InvalidOperationException($"No assembly was found for {callingType.Name}.");
            }

            RegisterOnBeforeStoreEvents(assembly);

            RegisterOnAfterConversionToEntityEvents(assembly);
        }

        private void RegisterOnBeforeStoreEvents(Assembly assembly)
        {
            IEnumerable<IOnBeforeStoreEvent> onBeforeStoreEvents =
                GetAllImplementationsOf<IOnBeforeStoreEvent>(assembly);

            foreach (IOnBeforeStoreEvent onBeforeStoreEvent in onBeforeStoreEvents)
            {
                _documentStore.OnBeforeStore += onBeforeStoreEvent.Handle;
            }
        }

        private void RegisterOnAfterConversionToEntityEvents(Assembly assembly)
        {
            IEnumerable<IOnAfterConversionToEntityEvent> onAfterConversionToEntityEvents =
                GetAllImplementationsOf<IOnAfterConversionToEntityEvent>(assembly);

            foreach (IOnAfterConversionToEntityEvent onAfterConversionToEntityEvent in onAfterConversionToEntityEvents)
            {
                _documentStore.OnAfterConversionToEntity += onAfterConversionToEntityEvent.Handle;
            }
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
