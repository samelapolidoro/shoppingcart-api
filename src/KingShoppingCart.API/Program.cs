using AutoMapper;
using KingShoppingCart.API.Mappers;
using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Services;
using KingShoppingCart.Infra.Data;
using KingShoppingCart.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(i =>
{
    i.AddProfile(new ApiMappingProfile());
});
IMapper mapper = new Mapper(mapperConfig);
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<KingShoppingCartContext>(i => i.UseInMemoryDatabase("KingShoppingCart"));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
