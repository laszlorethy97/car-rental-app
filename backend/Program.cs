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

            // Adatbázis és menedzserek
            builder.Services.AddDbContext<CarRentalDbContext>();
            builder.Services.AddScoped<CarManager>();
            builder.Services.AddScoped<InvoiceManager>();
            builder.Services.AddScoped<RentalManager>();
            builder.Services.AddScoped<UserManager>();

            // Controllers
            builder.Services.AddControllers().AddNewtonsoftJson();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ✅ CORS engedélyezése Angular localhost-ra
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDev", policy =>
                {
                    policy.WithOrigins("http://localhost:4200") // csak Angular dev server
                          .AllowAnyHeader()                   // Content-Type, Authorization stb.
                          .AllowAnyMethod();                  // GET, POST, PUT, DELETE
                });
            });

            var app = builder.Build();

            app.UseHttpsRedirection();

            // ✅ CORS middleware-t ide kell tenni a UseAuthorization elé
            app.UseCors("AllowAngularDev");

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}