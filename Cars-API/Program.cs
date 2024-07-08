using Cars_Core.Context;
using Cars_Core.IRepos;
using Cars_Core.Iservices;
using Cars_Infra.Repos;
using Cars_Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<CarDBContext>(
    cnn => cnn.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnect")));

builder.Services.AddScoped<ICarServices,CarServices>();
builder.Services.AddScoped<ICarRepos, CarRepos>();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Accounting Management",
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
string loggerPath = configuration.GetSection("Logger").Value;

Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).
                WriteTo.File(loggerPath, rollingInterval: RollingInterval.Day).
                CreateLogger();


var app = builder.Build();

try
{
    Log.Information("Food Recipe API Has been Launched Successfully");
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseStaticFiles(); 
    // To serve files 
    //                      // Add custom static files middleware
    //var imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
    //app.UseStaticFiles(new StaticFileOptions
    //{
    //    FileProvider = new PhysicalFileProvider(imagesDirectory),
    //    RequestPath = "/Images"
    //});

    app.UseAuthorization();

    app.MapControllers();

    app.Run();


}
catch (Exception ex)
{
    Log.Error("Something Went Wrong On Starting Application");
    Log.Error($"Error: {ex}");
}