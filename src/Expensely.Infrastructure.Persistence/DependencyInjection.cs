using Expensely.Application.Documents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Expensely.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RavenDbSettings>(configuration.GetSection(nameof(RavenDbSettings)));

            services.AddSingleton<IDocumentStoreProvider, DocumentStoreProvider>();

            services.AddScoped(serviceProvider => serviceProvider
                .GetRequiredService<IDocumentStoreProvider>()
                .GetDocumentStore()
                .OpenAsyncSession());

            return services;
        }
    }
}
