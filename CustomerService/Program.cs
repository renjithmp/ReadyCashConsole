using CustomerCore.Actions;
using CustomerCore.Model;
using MessagingSubscriber;
using MessagingSubscriber.Consumers;
using Microsoft.EntityFrameworkCore;
using Serilog;

// The initial "bootstrap" logger is able to log errors during start-up. It's completely replaced by the
// logger configured in `UseSerilog()` below, once configuration and dependency-injection have both been
// set up successfully.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up!");

var builder = WebApplication.CreateBuilder(args);

// Configuring the Serilog logger for the host
builder.Host.UseSerilog((context, services, configuration) => configuration
              .ReadFrom.Configuration(context.Configuration)
              .ReadFrom.Services(services)
              .Enrich.FromLogContext()
              .WriteTo.Console());

// Add services to the container.
string loanDBConnectionstring = "Host=localhost; Database=customer; Username=webuser; Password=SocGen01*";//ConfigurationManager.ConnectionStrings["localPgsqlCustomer"].ConnectionString;

builder.Services.AddDbContextFactory<CustomerDbContext>(options => options.UseNpgsql(loanDBConnectionstring), lifetime: ServiceLifetime.Scoped);
builder.Services.AddSingleton<CustomerTransactionsTracker>();
builder.Services.AddSingleton<CustomerTransactionsConsumer>();

builder.Services.AddSingleton<ITransactionConsumer>(
    sp => sp.GetRequiredService<CustomerTransactionsConsumer>());
builder.Services.AddSingleton<ConsumerSettings>();
builder.Services.AddHostedService<KafkaConsumer>();
builder.Services.AddScoped<CustomerActions>();
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

