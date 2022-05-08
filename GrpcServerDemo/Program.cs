using GrpcShared.Ioc;
using GrpcServerDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongoDb(builder.Configuration["ConnectionStrings:MongoDbConString"].ToString());
builder.Services.AddUserRepositories();

builder.Services.AddGrpc();


var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<GreeterService>();
    endpoints.MapGrpcService<AuthorService>();
    endpoints.MapGrpcService<BookService>();

    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
    });
});


app.Run();
