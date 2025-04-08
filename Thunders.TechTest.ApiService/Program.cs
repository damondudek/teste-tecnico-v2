using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.ApiService;
using Thunders.TechTest.ApiService.Database;
using Thunders.TechTest.OutOfBox.Cache;
using Thunders.TechTest.OutOfBox.Database;
using Thunders.TechTest.OutOfBox.Queues;
using Thunders.TechTest.OutOfBox.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddControllers();

var features = Features.BindFromConfiguration(builder.Configuration);

// Add services to the container.
builder.Services.AddProblemDetails();

if (features.UseMessageBroker)
{
    builder.Services.AddBus(builder.Configuration, new SubscriptionBuilder());
}

if (features.UseEntityFramework)
{
    builder.Services.AddSqlServerDbContext<DbContext>(builder.Configuration);
}

if (features.UseCache)
{
    builder.Services.AddCache(builder.Configuration);
}

if (features.UseSwagger)
{
    builder.Services.AddSwagger();
}

var app = builder.Build();

if (features.UseSwagger)
{
    app.AddSwagger();
}

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapDefaultEndpoints();

app.MapControllers();

app.Run();
