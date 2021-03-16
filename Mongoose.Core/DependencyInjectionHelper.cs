using Microsoft.Extensions.DependencyInjection;
using Mongoose.Core.Repository;

namespace Mongoose.Core
{
    public static class DependencyInjectionHelper
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISeriesRepository, SeriesRepository>();
            return serviceCollection;
        }
    }
}