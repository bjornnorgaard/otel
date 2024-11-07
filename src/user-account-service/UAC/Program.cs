using UAC.Background;
using UAC.Configuration;
using UAC.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.RegisterOptions<ServiceOptions>();
builder.Services.AddHostedService<TicketService>();

builder.AddTelemetry();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "Hello World!");
app.Run();