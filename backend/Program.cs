using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRentalSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CarRentalDbContext>();
            builder.Services.AddScoped<CarManager>();
            builder.Services.AddScoped<InvoiceManager>();
            builder.Services.AddScoped<RentalManager>();
            builder.Services.AddScoped<UserManager>();

            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDev", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseCors("AllowAngularDev");

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}