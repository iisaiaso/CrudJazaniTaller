using Autofac;
using Autofac.Extensions.DependencyInjection;
using Jazani.Application.Cores.Contexts;
using Jazani.Infastructure.Cores.Contexts;
using Serilog.Events;
using Serilog;
using Jazani.Api.Filters;
using Jazani.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//serilog para loggin 
var logger = new LoggerConfiguration()
    .WriteTo.Console(LogEventLevel.Information)
    .WriteTo.File(
        ".." + Path.DirectorySeparatorChar + "logapi.log",
        LogEventLevel.Warning,
        rollingInterval: RollingInterval.Day
    )
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.

// Para agregar los filter de la validation
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ValidationFilter());
});

//Route Options
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Infrastructure
builder.Services.AddInfrastructureServices(builder.Configuration);


// Aplications
builder.Services.AddAplicationServices();

//Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterModule(new InfrastructureAutofacModule());
        options.RegisterModule(new ApplicationAutofacModule());
    });

//API
builder.Services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
