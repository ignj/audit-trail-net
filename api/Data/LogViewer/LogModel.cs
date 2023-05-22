using MongoDB.Bson;

namespace api.Data.LogViewer;
public class AuditLogModel
{
    public string Id { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Application { get; set; } = null!;
    public BsonDocument Data { get; set; } = default!;
}