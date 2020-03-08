using Expensely.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Expensely.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RavenDbSettings>(configuration.GetSection(nameof(RavenDbSettings)));

            services.AddTransient(serviceProvider =>
                serviceProvider.GetService<IOptions<RavenDbSettings>>().Value);

            services.AddSingleton<IDocumentStoreProvider, DocumentStoreProvider>();

            services.AddScoped(serviceProvider => serviceProvider
                .GetRequiredService<IDocumentStoreProvider>()
                .GetDocumentStore()
                .OpenAsyncSession());

            return services;
        }
    }
}
