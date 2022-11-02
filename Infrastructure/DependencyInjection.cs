using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            services.AddSingleton<IMongoClient>(mongoClient);

            return services;
        }
    }
}
