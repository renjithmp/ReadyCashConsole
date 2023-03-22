using LoanCore.Actions;
using LoanCore.Model;
using LoanService.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string loanDBConnectionstring = "Host=localhost; Database=loan; Username=webuser; Password=SocGen01*";//ConfigurationManager.ConnectionStrings["localPgsqlCustomer"].ConnectionString;

builder.Services.AddControllers();
builder.Services.AddScoped<LoanAccountService>();
builder.Services.AddDbContext<LoanDbContext>(options => options.UseNpgsql(loanDBConnectionstring));
builder.Services.AddScoped<LoanActions>();
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

