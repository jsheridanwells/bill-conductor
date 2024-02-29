using BillConductor.Application.HealthCheck.Commands;
using BillConductor.Application.HealthCheck.Queries;
using BillConductor.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// TODO : Try out Autofac for this
builder.Services.AddDbContext<BillConductorContext>(opt =>
{
    var baseConnectionString = "Data Source= bill_conductor.db";
    var connectionString = new SqliteConnectionStringBuilder(baseConnectionString)
    {
        Mode = SqliteOpenMode.ReadWriteCreate,
    }.ToString();

    opt.UseSqlite(connectionString);
});
builder.Services.AddTransient<ISendHealthCheckCommandHandler, SendHealthCheckCommandHandler>();
builder.Services.AddTransient<IGetHealthCheckQueryHandler, GetHealthCheckQueryHandler>();
// ENDTODO :

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
