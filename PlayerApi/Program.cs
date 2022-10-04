using PlayerRepository;
using PlayerServices.Services;
using PlayerRepository.Context;
using PlayerRepository.Interfaces;
using Azure.Identity;
using PlayerServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppConfig");

builder.Host.ConfigureAppConfiguration(builder =>
    {
        //Connect to your App Config Store using the connection string
        builder.AddAzureAppConfiguration(options =>
        {
       
            
           options.Connect(new Uri("https://propertymanagementconfig.azconfig.io"), new DefaultAzureCredential()).UseFeatureFlags();
            
           // options.Connect(connectionString)
            //    .Select("ConnectionString");
        
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
builder.Services.AddScoped<IPlayersService, PlayerService>();

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