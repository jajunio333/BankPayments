using BankPayments.Business;
using BankPayments.Infrastructure;
using BankPayments.Interfaces;
using BankPayments.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<BankPaymentsManagerDBContext>(options =>
{
    options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
});

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBancoRepository, BancoRepository>();
builder.Services.AddScoped<IBoletoRepository, BoletoRepository>();
builder.Services.AddScoped<IBankPaymentsBusiness, BankPaymentsBusiness>();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1",
              new OpenApiInfo
              {
                  Title = "API DE GERENCIAMENTO DE BOLETOS BANCARIOS",
                  Version = "v1",
                  Description = "API de serviços internos"
              });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.EnableDeepLinking();
    options.DefaultModelsExpandDepth(0);

});

app.UseAuthorization();

app.MapControllers();

app.Run();




