using FluentAssertions.Common;
using MediatR;
using Questao5.Infrastructure.Conta;
using Questao5.Infrastructure.Idempotencia;
using Questao5.Infrastructure.Movimento;
using Questao5.Infrastructure.Sqlite;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();

builder.Services.AddSingleton<IContaCorrenteProvider, ContaCorrenteProvider>();
builder.Services.AddSingleton<IContaCorrenteRepository, ContaCorrenteRepository>();

builder.Services.AddSingleton<IMovimentoProvider, MovimentoProvider>();
builder.Services.AddSingleton<IMovimentoIdProvider, MovimentoIdProvider>();
builder.Services.AddSingleton<IMovimentoRepository, MovimentoRepository>();

builder.Services.AddSingleton<IIdempotenciaProvider, IdempotenciaProvider>();
builder.Services.AddSingleton<IIdempotenciaRepository, IdempotenciaRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

// sqlite
#pragma warning disable CS8602 // Dereference of a possibly null reference.
app.Services.GetService<IDatabaseBootstrap>().Setup();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

app.Run();

// Informações úteis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html


