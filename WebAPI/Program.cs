using Application;
using Application.Mapping;
using Microsoft.OpenApi.Models;
using Persistence;
using System.Reflection;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();

builder.Services.AddAutoMapper(opts =>
{
    opts.AddProfile(new ProfileForAssembly(Assembly.GetExecutingAssembly()));
    opts.AddProfile(new ProfileForAssembly(typeof(ProfileForAssembly).Assembly));
});

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(opts => 
    opts.SwaggerDoc("definition", 
        new OpenApiInfo() 
        { 
            Title = "KROK Keys register WebAPI"
        }
    )
);

var app = builder.Build();

app.UseCustomExceptionHandler();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwagger(opts => opts.RouteTemplate = "api/documentation/{documentName}.json");
app.UseSwaggerUI(opts =>
{
    opts.RoutePrefix = "api/documentation";
    opts.SwaggerEndpoint("definition.json", "KROK Keys register WebAPI");
});

app.Run();
