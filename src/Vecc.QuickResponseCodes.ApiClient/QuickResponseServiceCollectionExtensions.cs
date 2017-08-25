using System;
using Microsoft.Extensions.Configuration;
using Vecc.QuickResponseCodes.Abstractions;
using Vecc.QuickResponseCodes.ApiClient;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class QuickResponseCodesServiceCollectionExtensions
    {
        public static IServiceCollection AddQuickResponseCodeApiClient(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IQuickResponseCodeGenerator, ApiClient>();

            return serviceCollection;
        }

        public static IServiceCollection AddQuickResponseCodeApiClient(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddQuickResponseCodeApiClient();
            serviceCollection.Configure<ApiClient>(configuration);

            return serviceCollection;
        }

        public static IServiceCollection AddQuickResponseCodeApiClient(this IServiceCollection serviceCollection, Action<ApiClient> configureOptions)
        {
            serviceCollection.AddQuickResponseCodeApiClient();
            serviceCollection.Configure(configureOptions);

            return serviceCollection;
        }

        public static IServiceCollection AddQuickResponseCodeApiClient(this IServiceCollection serviceCollection, string name, IConfiguration configuration)
        {
            serviceCollection.AddQuickResponseCodeApiClient();
            serviceCollection.Configure<ApiClient>(name, configuration);

            return serviceCollection;
        }

        public static IServiceCollection AddQuickResponseCodeApiClient(this IServiceCollection serviceCollection, string name, Action<ApiClient> configureOptions)
        {
            serviceCollection.AddQuickResponseCodeApiClient();
            serviceCollection.Configure(name, configureOptions);

            return serviceCollection;
        }
    }
}
