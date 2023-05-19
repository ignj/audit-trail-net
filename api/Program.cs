using System.Text;
using Context;
using Dapr;
using Models;
using MongoDB.Bson;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<LogsContext>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.MapPost("/log", [Topic("pubsub", "log")] async (AuditLogInputDto log, LogsContext ctx) =>
{
    await ctx.CreateAsync(new AuditLog
    {
        Date = log.Date,
        Application = log.Application,
        Data = BsonDocument.Parse(log.Data)
    });
});
app.MapPost("/logs", async (SearchQuery searchQuery, LogsContext ctx) =>
{
    return Results.Content(await ctx.GetAsync(searchQuery), "application/json");
});
app.Run();