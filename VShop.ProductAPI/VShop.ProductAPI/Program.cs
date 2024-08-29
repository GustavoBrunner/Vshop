using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using VShop.ProductAPI.Context;
using VShop.ProductAPI.Repositories;
using VShop.ProductAPI.Repositories.Contracts;
using VShop.ProductAPI.Services;
using VShop.ProductAPI.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions( 
    //line of code responsible for ignoring cycle references in serialization
    jo => jo.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration
    .GetConnectionString(nameof(ProductApiContext));



builder.Services.AddDbContext<ProductApiContext>(options => 
    options.UseMySql(connectionString,
    ServerVersion.AutoDetect(connectionString)));


//dependency injection
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnityOfWork));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(opt =>
    opt.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
