using Microsoft.OpenApi.Models;
using Student_Journal_Manager.Context;
using Student_Journal_Manager.Repositories;
using Student_Journal_Manager.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Student_Journal_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Student Journal Manager API", Version = "v1" });
            });

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            ConfigureServices(builder.Services, configuration);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Journal Manager API v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ILessonService, LessonService>();

            services.AddScoped<IInvoiceDataRepository, InvoiceDataRepository>();
            services.AddScoped<IInvoiceDataService, InvoiceDataService>();

            services.AddScoped<IGuardianRepository, GuardianRepository>();
            services.AddScoped<IGuardianService, GuardianService>();

            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IAttendanceService, AttendanceService>();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();
            
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IPromotionService, PromotionService>();

            var connectionString = "Server=.;Database=StudentJournalManager;trusted_connection=true;TrustServerCertificate=true;";

            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
