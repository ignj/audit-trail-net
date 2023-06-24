using api.Data.LogViewer;
using Context;
using Dapr;
using Models;
using MongoDB.Bson;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddYamlFile("appsettings.Development.yaml", true);
builder.Configuration.AddYamlFile("appsettings.yaml");

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<LogsContext>();
builder.Services.AddSingleton<LogViewerService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapPost("/log", [Topic("pubsub", "log")] async (AuditLogInputDto log, LogsContext ctx) =>
{
    var document = BsonDocument.Parse(log.Data);
    document.Add("date", log.Date);
    document.Add("application", log.Application);

    await ctx.CreateAsync(new AuditLog
    {
        Data = document
    });
});
// app.MapPost("/logs", async (SearchQuery searchQuery, LogsContext ctx) =>
// {
//     return Results.Content(await ctx.GetAsync(searchQuery), "application/json");
// });

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();