using GrpcClientDemo.Config;
using GrpcShared.Ioc;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddMongoDb(builder.Configuration["ConnectionStrings:MongoDbConString"].ToString());
builder.Services.AddUserRepositories();

builder.Services.AddControllersWithViews();

builder.Services.AddApiVersioningConfiguration();

builder.Services.AddSwaggerGenConfiguration();

builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book API V1"); });
    //app.UseSwagger();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwaggerUIConfiguration(app);
app.UseRouting();
app.UseAuthorization();
app.MapControllers();


app.Run();
