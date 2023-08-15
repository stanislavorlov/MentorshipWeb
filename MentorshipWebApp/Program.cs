using Microsoft.OpenApi.Models;
using MentorshipWebApp;
using MentorshipWebApp.Interface;
using MentorshipWebApp.Repositories;
using MentorshipWebApp.Model;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddCommandLine(args);
builder.Configuration.AddEnvironmentVariables();

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.Configure<ProductSettings>(builder.Configuration.GetSection("ProductSettingsConfiguration"));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(o => {
    o.IdleTimeout = TimeSpan.FromMinutes(20);
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

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

builder.Services.AddControllers();

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

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseExceptionHandler(config => config.Run(async context => await context.Response.WriteAsync("")));

app.UseStatusCodePages(async (StatusCodeContext statusCodeContext) =>
{
    var response = statusCodeContext.HttpContext.Response;

    switch (response.StatusCode)
    {
        case 401:
            await response.WriteAsync("");
            break;
        case 403:
            response.Redirect("/Login");
            break;
        case 404:
        case 400:
        case 500:
            //_logger.LogError("");
            break;
    }
});

app.UseSession();

//app.Run(async (context) =>
//{
//    int a = 5;
//    int b = 0;
//    int c = a / b;
        
//    await context.Response.WriteAsync(c.ToString());
//});

app.Run();