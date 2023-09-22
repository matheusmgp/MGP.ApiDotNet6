using MGP.ApiDotNet6.Application.Mappers;
using MGP.ApiDotNet6.Application.Services.Interfaces;
using MGP.ApiDotNet6.Application.Services;
using MGP.ApiDotNet6.Domain.Repositories;
using MGP.ApiDotNet6.Infra.Data.Context;
using MGP.ApiDotNet6.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//db
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//repositories
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
//services
builder.Services.AddAutoMapper(typeof(ConfigureAutoMapper));
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddMvc().AddJsonOptions(opt => 
opt.JsonSerializerOptions.DefaultIgnoreCondition= JsonIgnoreCondition.WhenWritingNull);

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
