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

    public async Task<List<AuditLog>> GetAsync(string filters, string ordering, int pageNumber = 1, int pageSize = 10)
    {
        var queryFilters = string.IsNullOrEmpty(filters)
            ? new BsonDocument()
            : MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(filters);

        // Create a sort order.
        var queryOrder = string.IsNullOrEmpty(ordering)
            ? new BsonDocument()
            : MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(ordering);

        return await _auditLogsCollection
            .Find(queryFilters)
            .Sort(queryOrder)
            .Skip(pageSize * (pageNumber - 1))
            .Limit(pageSize)
            .ToListAsync();
    }

    public async Task CreateAsync(AuditLog log)
    {
        await _auditLogsCollection.InsertOneAsync(log);
    }
}