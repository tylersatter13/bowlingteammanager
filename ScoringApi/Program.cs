using ScoringRepository.Context;
using ScoringRepository.Interfaces;
using ScoringRepository.Repository;
using ScoringServices.Interfaces;
using ScoringServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ScoringRepositoryContext>();
builder.Services.AddScoped<IScoringRequestService, ScoringRequestService>();
builder.Services.AddScoped<IScoringRequestRepository, ScoringRequestRepository>();

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