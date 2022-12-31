using API.Extensions;
using API.Helpers;
using API.MiddleWare;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;
var _config = builder.Configuration;

// Add services to the container.
service.AddControllers();
service.AddAutoMapper(typeof(MappingProfiles));
service.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(_config.GetConnectionString("Path")));

service.AddSingleton<IConnectionMultiplexer, ConnectionMultiplexer>(c =>
{
    var configuration = ConfigurationOptions.Parse(_config.GetConnectionString("Redis"), true);
    return ConnectionMultiplexer.Connect(configuration);
});


//Used for the extension of services
service.AddApplicationService();

// services.AddDbContext<ApplicationDbContext>(opt =>
// {
//     opt.UseSqlite(builder.Configuration.GetConnectionString("Path"));
// });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
service.AddEndpointsApiExplorer();

service.SwaggerExtension();
service.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", opt =>
    {
        opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();
        //await StoreContextSeed.SeedAsync(context, loggerFactory);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An Error occured during Migration");
    }
}

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleWare>();

app.SwaggerDocumentation();

//app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseStatusCodePagesWithReExecute("/error/{0}");

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
