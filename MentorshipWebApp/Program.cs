using Microsoft.OpenApi.Models;
using MentorshipWebApp;
using MentorshipWebApp.Interface;
using MentorshipWebApp.Repositories;
using MentorshipWebApp.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddCommandLine(args);
builder.Configuration.AddEnvironmentVariables();

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.Configure<ProductSettings>(builder.Configuration.GetSection("ProductSettingsConfiguration"));

var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.SetMinimumLevel(LogLevel.Debug);
});

//builder.Services.AddSingleton<ILoggerFactory>(loggerFactory);

builder.Logging
    .AddConsole();
    //.SetMinimumLevel(LogLevel.Debug);

// every service invocation generates a new instance per Method
builder.Services.AddSingleton<IProductService, ProductService>();

//// every service per Request (HttpRequest, Event, Timer)
builder.Services.AddSingleton<IProductRepo, ProductRepo>();

//// single instance per application
//builder.Services.AddSingleton<IProductService, ProductService3>();

builder.Services
    .AddControllers()
    .AddMvcOptions((options) => { });

builder.Services.AddSwaggerGen(options =>
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    }));

builder.Services
    .AddAuthentication()
    .AddCookie();

var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.Cookies.Append("mentorship", "Svitlana");

    await next();
});

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<CustomMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();      //start application