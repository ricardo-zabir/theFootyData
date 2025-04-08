using Microsoft.EntityFrameworkCore;
using theFootyDataWebAPI.Repository;
using theFootyDataWebAPI.Services;
using theFootyDataWebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? connectionString = builder.Configuration.GetConnectionString("DbConnection");


builder.Services.AddSingleton<MatchService>();
builder.Services.AddSingleton<footyDbContext>();
builder.Services.AddSingleton<IMatchRepository, MatchRepository>();
builder.Services.AddDbContextPool<footyDbContext>(option => option.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(builder => builder.AllowAnyOrigin());
app.MapControllers();

app.Run();

