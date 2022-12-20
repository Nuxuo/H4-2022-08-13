using Services;
using Repositories;
using Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SCOPES
builder.Services.AddScoped<IHubRepos, HubRepos>();
builder.Services.AddScoped<IDataRepos, DataRepos>();
builder.Services.AddScoped<ILocationRepos, LocationRepos>();

// // MEMORY DATABASE
// builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("NERD_MemoryDatabase").EnableSensitiveDataLogging());

//mysql
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
 
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMvc(options =>
{
   options.SuppressAsyncSuffixInActionNames = false;
});

// OPTIONAL
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS
app.UseCors("corsapp");

// API KEY middleware
app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
