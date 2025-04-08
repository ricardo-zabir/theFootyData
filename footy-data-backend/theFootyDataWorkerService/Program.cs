using theFootyDataWorkerService;
using theFootyDataWorkerService.Repository;
using Hangfire;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore;
using Hangfire.AspNetCore;
using theFootyDataWorkerService.Models;


var builder = Host.CreateApplicationBuilder(args);
string? connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<DataUpsert>();
builder.Services.AddSingleton<footyDbContext>();
builder.Services.AddSingleton<IMatchRepository, MatchRepository>();
builder.Services.AddDbContextPool<footyDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddHangfire(configuration => configuration.UseSqlServerStorage(connectionString));
builder.Services.AddHangfireServer();

var host = builder.Build();
host.Run();

