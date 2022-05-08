using MongoDB.Driver;
using GrpcShared.Data;
using GrpcShared.Services;
using GrpcShared.Repositories.MongoRepos;
using Microsoft.Extensions.DependencyInjection;

namespace GrpcShared.Ioc
{
    public static class ServiceCollectionRegistery
    {


        public static void AddMongoDb(this IServiceCollection services, string conn)
        {
            //var conn = "mongodb://mongouser:1234@localhost:27017?authMechanism=DEFAULT&authSource=db&ssl=true";
            var mongoClient = new MongoClient(conn);
            services.AddSingleton<IMongoClient, MongoClient>(sp => mongoClient);

            services.AddScoped(sp => new BookDbContext(sp.GetRequiredService<IMongoClient>()));

        }
        public static void AddUserRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookapiService, BookapiService>();
            services.AddTransient<IAuthorapiService, AuthorapiService>();

         
        }

    }
}
