using System.Collections.Immutable;
using News.Application;
using News.Application.Interfaces;
using News.Backend.Infrastructure.Persistence;
using News.Persistance.DataBase;
using News.WebAPI.Middleware;
using System.Reflection;
using Microsoft.OpenApi.Models;
using News.WebAPI.Services;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .WriteTo.File("NewsWebAppLog-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

builder.Services.AddAutoMapper(
    Assembly.GetExecutingAssembly(),
    typeof(INewsDbContext).Assembly);

builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    })
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>  
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "News API", Version = "v1" }));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        NewsDbContext dbContext = scope.ServiceProvider.GetRequiredService<NewsDbContext>();
        DbInitializer.Initialize(dbContext);
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "An error occurred while initializing the database.");
    }
}

app.UseCustomExceptionHandler();
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "News API V1"); 
    c.RoutePrefix = "swagger"; 
});

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();