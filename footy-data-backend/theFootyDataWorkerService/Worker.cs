using Hangfire;
using theFootyDataWorkerService.Models;

namespace theFootyDataWorkerService;

public class Worker : BackgroundService
{

    private readonly footyDbContext _context;
    private readonly ILogger<Worker> _logger;
    private DataUpsert _dataUpsert;

    public Worker(ILogger<Worker> logger, DataUpsert dataUpsert, footyDbContext context)
    {
        _logger = logger;
        _dataUpsert = dataUpsert;
        _context = context;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        //await _dataUpsert.triggerDataUpsertFunc();
        RecurringJob.AddOrUpdate("data-upsert",() => _dataUpsert.triggerDataUpsertFunc(), Cron.Hourly);
        
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            await Task.Delay(5000, stoppingToken);
        }
        
    }
}