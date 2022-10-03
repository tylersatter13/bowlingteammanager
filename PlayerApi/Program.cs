using PlayerRepository;
using PlayerRepository.Context;
using PlayerRepository.Interfaces;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppConfig");

builder.Host.ConfigureAppConfiguration(builder =>
    {
        //Connect to your App Config Store using the connection string
        builder.AddAzureAppConfiguration(options =>
        {
            options.Connect(connectionString)
                .Select("ConnectionString");
        
        });
    })
    .ConfigureServices(services =>
    {
        services.AddControllersWithViews();
    });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPlayerRequestRepository, PlayerRequestRepository>();
builder.Services.AddScoped<PlayerRepositoryContext>();

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