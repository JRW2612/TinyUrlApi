using tinyUrl.Application.Contracts;
using tinyUrl.Infrastructure.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IShortCodeGenerator, Base62ShortCodeGenerator>();
builder.Services.AddSingleton<ZooKeeperService>();
var app = builder.Build();

// Wire ZooKeeper service: connect on start and close on shutdown.
var zk = app.Services.GetRequiredService<ZooKeeperService>();
var logger = app.Services.GetRequiredService<ILogger<Program>>();
app.Lifetime.ApplicationStarted.Register(async () =>
{
    try
    {
        await zk.ConnectAsync("localhost:2181", TimeSpan.FromSeconds(5));
        await zk.RegisterServiceAsync("tinyurl-api", "localhost", 5000);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Failed to initialize ZooKeeperService");
    }
});

app.Lifetime.ApplicationStopping.Register(async () =>
{
    try
    {
        await zk.UnregisterServiceAsync("tinyurl-api", "localhost", 5000);
        await zk.CloseAsync();
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error during ZooKeeperService shutdown");
    }
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.Run();

