using News.Application;
using News.Application.Interfaces;
using News.Backend.Infrastructure.Persistence;
using News.Persistance.DataBase;
using News.WebAPI.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(
    Assembly.GetExecutingAssembly(), 
    typeof(INewsDbContext).Assembly);

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
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        NewsDbContext dbContext = app.Services.GetRequiredService<NewsDbContext>();
        DbInitializer.Initialize(dbContext);
    }
    catch (Exception ex)
    {

    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
