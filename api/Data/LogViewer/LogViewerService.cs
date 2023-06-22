using Context;

namespace api.Data.LogViewer;

public class LogViewerService
{
    private readonly LogsContext _ctx;

    public LogViewerService(LogsContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<AuditLogModel[]> GetLogsAsync(string filters, string ordering, int pageNumber, int pageSize)
    {
        return (await _ctx.GetAsync(filters, ordering, pageNumber, pageSize))
            .Select(l => new AuditLogModel
            {
                Id = l.Id.ToString(),
                Data = l.Data,
            })
            .ToArray();
    }
}