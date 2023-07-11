using CustomerCore.Actions;
using CustomerCore.Model;
using MessagingSubscriber;
using MessagingSubscriber.Consumers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string loanDBConnectionstring = "Host=localhost; Database=customer; Username=webuser; Password=SocGen01*";//ConfigurationManager.ConnectionStrings["localPgsqlCustomer"].ConnectionString;


builder.Services.AddDbContextFactory<CustomerDbContext>(options => options.UseNpgsql(loanDBConnectionstring),lifetime:ServiceLifetime.Scoped);
builder.Services.AddSingleton<CustomerTransactionsTracker>();
builder.Services.AddSingleton<CustomerTransactionsConsumer>();


builder.Services.AddSingleton<ITransactionConsumer>(
    sp => sp.GetRequiredService<CustomerTransactionsConsumer>());
builder.Services.AddSingleton<ConsumerSettings>();
builder.Services.AddHostedService<KafkaConsumer>();
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

