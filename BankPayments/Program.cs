using BankPayments.Business;
using BankPayments.Infrastructure;
using BankPayments.Interfaces;
using BankPayments.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<BankPaymentsManagerDBContext>(options =>
{
    options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
});

builder.Services.AddScoped<IBancoRepository, BancoRepository>();
builder.Services.AddScoped<IBoletoRepository, BoletoRepository>();
builder.Services.AddScoped<IBankPaymentsBusiness, BankPaymentsBusiness>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
