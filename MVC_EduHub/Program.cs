using EduHub_Project.repository;
using Microsoft.EntityFrameworkCore;
using MVC_EduHub.Models;
using MVC_EduHub.repository;
using MVC_EduHub.services;

namespace MVC_EduHub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("MyConstr") ?? throw new InvalidOperationException("Connection string 'AppDBContextConnection' not found.");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IUserService, UserRepository>();
            builder.Services.AddScoped<IMaterialService, MaterialRepository>();





            builder.Services.AddScoped<ICourseService, CourseRepository>();
            builder.Services.AddScoped<IEnquiryService, EnquiryRepository>();
         
            builder.Services.AddScoped<IEnrollmentService, EnrollmentRepository>();
          
            builder.Services.AddTransient<IFeedbackService, FeedbackRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

           // app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
