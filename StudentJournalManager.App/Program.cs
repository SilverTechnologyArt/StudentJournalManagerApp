using Student_Journal_Manager.Context;
using Student_Journal_Manager.Repositories;
using Student_Journal_Manager.Services;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddScoped<System.Net.Http.HttpClient>(client =>
        {
            var httpClient = new System.Net.Http.HttpClient
            {
                BaseAddress = new Uri("https://localhost:7294")
            };
            return httpClient;
        });

        ConfigureServices(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }

    static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MyDbContext>();
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
    }
}