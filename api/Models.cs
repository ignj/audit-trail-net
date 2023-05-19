using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models;

public class AuditLogInputDto
{
    public DateTime Date { get; set; }
    public string Application { get; set; } = null!;
    public string Data { get; set; } = null!;
}

public class AuditLog
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }
    public DateTime Date { get; set; }
    public string Application { get; set; } = null!;
    public BsonDocument Data { get; set; } = default!;
}

public class MongoDbSettings
{
    public string ConnectionURI { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;
}

public class SearchQuery
{
    public string? Filters { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public bool DescOrder { get; set; } = true;
}
