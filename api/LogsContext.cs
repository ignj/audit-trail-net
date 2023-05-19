using Microsoft.Extensions.Options;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Context;

public class LogsContext
{
    private readonly IMongoCollection<AuditLog> _auditLogsCollection;

    public LogsContext(IOptions<MongoDbSettings> mongoDBSettings)
    {
        var client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _auditLogsCollection = database.GetCollection<AuditLog>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<dynamic> GetAsync(SearchQuery query)
    {
        var filters = string.IsNullOrEmpty(query.Filters)
            ? new BsonDocument()
            : MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(query.Filters);

        // Create a sort order.
        var sortOrder = query.DescOrder
            ? Builders<AuditLog>.Sort.Descending(al => al.Date)
            : Builders<AuditLog>.Sort.Ascending(al => al.Date);

        return
            (await _auditLogsCollection
                .Find(filters)
                .Sort(sortOrder)
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Limit(query.PageSize)
                .ToListAsync()
            )
            .ToJson();
    }

    public async Task CreateAsync(AuditLog log)
    {
        await _auditLogsCollection.InsertOneAsync(log);
    }
}