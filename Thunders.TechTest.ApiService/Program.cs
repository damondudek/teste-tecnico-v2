using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Thunders.TechTest.ApiService;
using Thunders.TechTest.ApiService.Api;
using Thunders.TechTest.ApiService.Database;
using Thunders.TechTest.ApiService.Handlers;
using Thunders.TechTest.ApiService.IoC;
using Thunders.TechTest.ApiService.Models.Mappers;
using Thunders.TechTest.OutOfBox.Cache;
using Thunders.TechTest.OutOfBox.Database;
using Thunders.TechTest.OutOfBox.Queues;
using Thunders.TechTest.OutOfBox.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddAutoMapper(typeof(TollMappingProfile));

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});

var features = Features.BindFromConfiguration(builder.Configuration);

if (features.UseMessageBroker)
{
    builder.Services.AddBus(builder.Configuration, new SubscriptionBuilder()
        .Add<ReportMessageHandler>()
        .Add<TollMessageHandler>());
}

if (features.UseEntityFramework)
{
    builder.Services.AddSqlServerDbContext<TollContext>(builder.Configuration);
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

if (features.UseApplyMigrations)
{
    app.ApplyMigrations<TollContext>();
}

app.BaseApiMap();
app.TollApiMap();
app.ReportApiMap();

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.MapDefaultEndpoints();

app.MapControllers();

app.Run();