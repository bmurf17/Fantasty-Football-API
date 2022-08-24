using Fantasty_Football_API.Data;
using Fantasty_Football_API.Services;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// database info
builder.Services.AddSingleton<ICosmosDbService>(ConfigCosmos.InitializeCosmosDbClient(config));

// add service implemntations
builder.Services.AddSingleton<ITeamService, TeamService>();
builder.Services.AddSingleton<IPlayerService, PlayerService>();


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
