using Context;

namespace api.Data.LogViewer;

public class LogViewerService
{
    private readonly LogsContext _ctx;

    public LogViewerService(LogsContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<AuditLogModel[]> GetLogsAsync(string? filters, int? pageNumber, int? pageSize, bool? descOrder)
    {
        return (await _ctx.GetAsync(filters ?? string.Empty, pageNumber.GetValueOrDefault(), pageSize.GetValueOrDefault(), descOrder.GetValueOrDefault()))
            .Select(l => new AuditLogModel
            {
                Id = l.Id.ToString(),
                Application = l.Application,
                Data = l.Data,
                Date = l.Date,
            })
            .ToArray();
    }
}