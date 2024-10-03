var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
string EnvironmentString = builder.Configuration.GetConnectionString("Environment");
config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddConfiguration(config) // Add base config
    .AddJsonFile($"appsettings.{EnvironmentString}.json", optional: true)
    .Build();
// Add services to the container.



//builder.Services.AddDbContext<AreaDbContext>(options => options.UseSqlServer(config.GetConnectionString("AreaDBconnectionString") ?? throw new InvalidOperationException("Connection string 'AreaDbContext' not found.")));

builder.Services.AddControllers();
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

app.Run();
