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

    public async Task<List<AuditLog>> GetAsync(string filters, int pageNumber = 1, int pageSize = 10, bool descOrder = true)
    {
        var queryFilters = string.IsNullOrEmpty(filters)
            ? new BsonDocument()
            : MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(filters);

        // Create a sort order.
        var sortOrder = descOrder
            ? Builders<AuditLog>.Sort.Descending(al => al.Date)
            : Builders<AuditLog>.Sort.Ascending(al => al.Date);

        return await _auditLogsCollection
            .Find(queryFilters)
            .Sort(sortOrder)
            .Skip(pageSize * (pageNumber - 1))
            .Limit(pageSize)
            .ToListAsync();
    }

    public async Task CreateAsync(AuditLog log)
    {
        await _auditLogsCollection.InsertOneAsync(log);
    }
}