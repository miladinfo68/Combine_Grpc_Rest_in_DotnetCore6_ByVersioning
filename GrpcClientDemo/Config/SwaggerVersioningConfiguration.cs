using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace GrpcClientDemo.Config;

public static class SwaggerVersioningConfiguration
{
    
    public static void AddApiVersioningConfiguration(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);

            // Set a default version when it's not provided,
            // e.g., for backward compatibility when applying versioning on existing APIs
            options.AssumeDefaultVersionWhenUnspecified = true;

            // ReportApiVersions will return the "api-supported-versions" and "api-deprecated-versions" headers.
            options.ReportApiVersions = true;

            // Combine (or not) API Versioning Mechanisms:
            // options.ApiVersionReader = ApiVersionReader.Combine(
            //     // The Default versioning mechanism which reads the API version from the "api-version" Query String paramater.
            //     new QueryStringApiVersionReader("v"),
            //     // Use the following, if you would like to specify the version as a custom HTTP Header.
            //     new HeaderApiVersionReader("x-api-version"),
            //     // Use the following, if you would like to specify the version as a Media Type Header.
            //     // e.g. in headers add Accept application/json;api-version=2.0
            //     new MediaTypeApiVersionReader("api-version")
            // );
        });

        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });
    }

    public static void AddSwaggerGenConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        // services.AddSwaggerGen(c =>
        // {
        //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Book API", Version = "v1" });
        //     c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        // });

         services.AddSwaggerGen();
        // services.AddSwaggerGen(c =>
        // {
        //     c.SwaggerDoc("v1", new OpenApiInfo
        //     {
        //         Version = "v1",
        //         Title = "Grpc && Rest API",
        //         Description = "A simple hybrid REST and gRPC service using ASP.NET Core 6.0",
        //         Contact = new OpenApiContact
        //         {
        //             Name = "Mahdi Jalai",
        //             Url = new Uri("https://www.linkedin.com/in/miladinfo/")
        //         },
        //         License = new OpenApiLicense
        //         {
        //             Name = "MIT License",
        //             Url = new Uri("https://github.com/bchen04/aspnetcore-grpc-rest/blob/master/LICENSE")
        //         }
        //     });

        //     c.DescribeAllParametersInCamelCase();

        //     // Set the comments path for the Swagger JSON and UI.
        //     var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        //     var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        //     c.IncludeXmlComments(xmlPath);
        // });

        services.ConfigureOptions<SwaggerGenOptionsConfiguration>();
    }
    public static IApplicationBuilder UseSwaggerUIConfiguration(this IApplicationBuilder app, IHost host)
    {
        app.UseSwagger();
        // app.UseSwaggerUI(options =>
        // {
        //     options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
        // });


        app.UseSwaggerUI(options =>
        {
            foreach (var description in host.Services.GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        });
        return app;
    }

}