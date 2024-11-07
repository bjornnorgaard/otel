using UAC.Background;
using UAC.Configuration;
using UAC.Extensions;
using UAC.Features;
using UAC.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.RegisterOptions<ServiceOptions>();
builder.Services.AddHostedService<TickerService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<UserRepository>();

builder.AddTelemetry();

var app = builder.Build();

app.MapGroup("users").MapGet("{id:guid}", async (UserService handler, Guid id) => await handler.GetUser(id));

app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "Hello World!");
app.Run();