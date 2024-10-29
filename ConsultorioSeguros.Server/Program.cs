
using Microsoft.EntityFrameworkCore;
using ConsultorioSeguros.Server.Data;
using ConsultorioSeguros.Server.Data.Repository;
using ConsultorioSeguros.Server.Interfaces;
using ConsultorioSeguros.Server.Dto;
using ConsultorioSeguros.Server.Services;

namespace ConsultorioSeguros.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(AppMapperProfile));

            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
            );

            builder.Services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            builder.Services.AddTransient(typeof(IClientRepository), typeof(ClientRepository));
            builder.Services.AddTransient(typeof(ClientService));
            builder.Services.AddTransient(typeof(InsurancePlanService));

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
