using FluentValidation;
using FluentValidation.AspNetCore;
using ProductApi.API.Middlewares;
using ProductApi.BLL.Interfaces;
using ProductApi.BLL.Services;
using ProductApi.BLL.Validators;
using ProductApi.DAL;

namespace ProductApi.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateProductRequestValidator>();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<IStatusCacheService, StatusCacheService>();
            builder.Services.AddSingleton(
                new DbConnectionFactory(
                    builder.Configuration.GetConnectionString("DefaultConnection")!));

            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddHttpClient<IDiscountService, DiscountService>(client =>
            {
                client.BaseAddress = new Uri(
                    builder.Configuration["DiscountApi:BaseUrl"]!);
            });

            builder.Services.AddScoped<IProductService, ProductService>();

    

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseMiddleware<RequestLoggingMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}