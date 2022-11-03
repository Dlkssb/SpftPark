using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;



namespace Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            services.AddSingleton<IMongoClient>(mongoClient);

            return services;
        }
    }
}
