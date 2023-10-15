using lan_game_hub_api;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var AllowAllHeaders = "AllowAllHeaders";

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAllHeaders,
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                          });
});

// database contex dependcy injection

var dbHost = "localhost";
var dbName = "lan-game-hub";
var dbPassword = "";

var connectionString = $"server={dbHost};port=3306;database={dbName};user=root;password={dbPassword}";
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(connectionString));

// -----------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowAllHeaders);

app.UseAuthorization();

app.MapControllers();

app.Run();
